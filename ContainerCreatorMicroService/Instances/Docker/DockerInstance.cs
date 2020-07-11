using InstanceMicroService.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docker.DotNet;
using System.IO;
using InstanceMicroService.Services.Docker;
using Docker.DotNet.Models;
using Tests.Core.Interfaces;
using System.Diagnostics;

namespace InstanceMicroService.Instances
{
    public class DockerInstance : IDockerInstance
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        private string testsDockerFileDirectory = "";
        private string dockerTestRunnerContainerName = "dockertestrunner:dev";
        private string defaultDockerNetwork = "localdev";
        private StringBuilder log = new StringBuilder();
        public DockerInstance()
        {

//            var xx = (new FileInfo(AppDomain.CurrentDomain.BaseDirectory)).Directory.Parent.FullName;
            testsDockerFileDirectory = @"D:\Projekty\MgrAngularWithDockers\DockerTestRunner";
            //testsDockerFileDirectory = Path.Combine(new string[] { AppDomain.CurrentDomain.BaseDirectory, @"..\TestsDockerFile" });
        }

        public Task Destroy()
        {
            throw new NotImplementedException();
        }

        public Task Pause()
        {
            throw new NotImplementedException();
        }

        public async Task StartTest(ITest test)
        {
            try
            {
                await CreateDockerContainer();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task CreateDockerContainer()
        {
            using var dockerClient = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
            var dockerTestRunnerImage = await dockerClient.Images.ListImagesAsync(new ImagesListParameters() { MatchName = dockerTestRunnerContainerName });
            var containerName = GenerateName(5);

            var allNetworks = await dockerClient.Networks.ListNetworksAsync();
            var networkSettings = new EndpointSettings() { Aliases = new List<string>() { defaultDockerNetwork }, NetworkID = allNetworks.First(x=> x.Name.ToLower().Equals(defaultDockerNetwork)).Name };
            var networkDictionary = new Dictionary<string, EndpointSettings>();
            networkDictionary.Add(defaultDockerNetwork, networkSettings);

            var createContainerParameters = new CreateContainerParameters() { Image = dockerTestRunnerContainerName, Hostname = $"dockertestrunner-{containerName}", NetworkingConfig = new NetworkingConfig() {EndpointsConfig = networkDictionary}};
            var createContainerResponse = await dockerClient.Containers.CreateContainerAsync(createContainerParameters);
            
            var startContainerResponse = await dockerClient.Containers.StartContainerAsync(createContainerResponse.ID, new ContainerStartParameters() { DetachKeys = "-d"});
        }

        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }

        public void CreateDockerTestRunnerImage(string targetName, string pathToDockerFile)
        {
            try
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = $"/C docker build -t {targetName} -f {pathToDockerFile}/Dockerfile {pathToDockerFile}"
                };
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
