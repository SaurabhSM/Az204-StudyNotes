# Provision VMs

There are three different ways to provision a VM
1. Through Azure Portal
2. Through Powershell
3. Through Azure CLI 

### Steps to create a new VM
1. Create Resource Group
2. Create VM
3. Connect to VM.
4.  Install Additional Softwares (optional)


### Provisioning VM using Azure Portal
Since AZ 204 is developer certification, skipping the exercises using the azure portal. 

Refer https://docs.microsoft.com/en-us/azure/virtual-machines/windows/quick-create-portal if needed.

### Provisioning VM using Powershell

Step 1: Login to Azure

```powerwhell 
Connect-AzAccount
```

Step 2: Create a resource Group

```powershell
New-AzResourceGroup 
    -Name "az204StudyRg" `
    -Location "CentralUS"
```

Step 3: Create new VM

```powershell
New-AzVm 
    -ResourceGroupName "az204StudyRg" `
    -Name "studyVm" `
    -Location "CentralUS" `
    -VirtualNetworkName "studyVNet" `
    -SecurityGroupName "studyNSG" `
    -PublicIpAddressName "studyPubIp" `
    -OpenPorts 80,3389
```


### Provisioning VM using Azure CLI

Step 1: Login to Azure

Step 2: Create a resource Group

```bash 
az group create  \
    --name az204StudyRg \
    --location centralus
```

Step 3: Create new VM

```bash
az vm create \ 
    --resource-group az204StudyRg \ 
    --name studyVm \
    --image UbuntuLTS
```

*Tip: Check out Mindmap for powershell or Azure CLI for quick review*