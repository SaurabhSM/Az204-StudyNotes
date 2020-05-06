using System;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace CreateVm
{
    class Program
    {
        const string subscription = "";
        const string client = "";
        const string secret = "";
        const string tenant = "";
        const string managementUrl = "https://management.core.windows.net";
        const string baseUrl = "https://management.azure.com";
        const string authUrl = "https://login.windows.net";
        const string graphUrl = "https://graph.microsoft.com";
        static void Main(string[] args)
        {
            // create managment client
            var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(client, secret, tenant, AzureEnvironment.AzureGlobalCloud);

            var azure = Azure.Configure().WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .Authenticate(credentials).WithDefaultSubscription();

            // Create resource group
            string rgName = "testRg";
            string vmName = "testVm";
            Region location = Region.USCentral;

            // note how we define attributes first and then call create method
            var resourceGroup = azure.ResourceGroups
                .Define(rgName)
                .WithRegion(location)
                .Create();

            //create availability set
            string avSetName = "testAvSet";
            var availbilitySet = azure.AvailabilitySets
                .Define(avSetName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                .Create();

            // create public IP
            string publicIpAddressName = "testPublicIpAddress";
            var publicIpAddress = azure.PublicIPAddresses
                .Define(publicIpAddressName)
                .WithRegion(location)
                .WithExistingResourceGroup(resourceGroup)
                .WithDynamicIP()
                .Create();
        }
    }
}
