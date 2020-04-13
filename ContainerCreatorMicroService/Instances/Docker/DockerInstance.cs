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

namespace InstanceMicroService.Instances
{
    public class DockerInstance : IDockerInstance
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        private string testsDockerFileDirectory = "";

        public DockerInstance()
        {

//            var xx = (new FileInfo(AppDomain.CurrentDomain.BaseDirectory)).Directory.Parent.FullName;
            testsDockerFileDirectory = @"D:\Projekty\MgrAngularWithDockers\SimpleDockerTests";
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
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task CreateDockerContainer()
        {
            var testsDockerFileTarStream = DockerStreamService.CreateTarballForDockerfileDirectory(testsDockerFileDirectory);
            var imageBuildParameters = new ImageBuildParameters() { Tags = new List<string>() { "tests:dev" } /*Dockerfile = "TestsDockerFile"*/ };

            using var dockerClient = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
            var xx = await dockerClient.Images.ListImagesAsync(new Docker.DotNet.Models.ImagesListParameters() { }, new System.Threading.CancellationToken());
            var yy = xx.Select(x => x.RepoTags).ToList();
            using var responseStream = await dockerClient.Images.BuildImageFromDockerfileAsync(testsDockerFileTarStream, imageBuildParameters);
            var xx2 = await dockerClient.Images.ListImagesAsync(new Docker.DotNet.Models.ImagesListParameters() { }, new System.Threading.CancellationToken());

            /////
            //DockerClient client = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine"), null).CreateClient();

        }
    }
}
