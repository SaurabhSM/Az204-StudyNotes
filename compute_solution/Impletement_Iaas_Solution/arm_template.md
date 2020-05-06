# ARM Template

- ARM provides a way to use Azure as Infrastucture as Service platform.
- It allows to automate the process of deployment by creating JSON formatted document known as ARM templates.
- ARM template JSON gets converted to Azure REST API calls when template is being deployed.
- It is possible to divide the templates into different sections and write multiple sub-templates in order to create a template. These are called **Linked templates.**

#### Sections of ARM Templates

1. Parameters - Provides values during deployment of the template.
2. Variables - Defines values that can be reused throughout the template.
3. User-defined functions - These are functions that are created by the user. We can use the user-defined functions to create dynamic values. However, we cannot call another user defined function inside a user-defined function. But, use of system functions are allowed in the user defined functions. Also we cannot use template variables inside the user-defined functions. All variable defined in the functions are localized in the scope.
4. Resources - These are the resources that we want to deploy using ARM templates. We could provide the dependacies of these resources while creating them.
5. Outputs - Return values from the deployed resources.

#### Ways to create ARM template

There are multiple ways to create an ARM template but following are most often used.

1. Azure Portal
2. VS Code
3. Visual Studio

`Note: Template that is being used in the command line is avaiable in 'source' directory.`

#### Deploying Templates

**Using Azure CLI**

```bash
az deployment group create \
    --resource-group az-204-study-rg \
    --template-file arm-template.json \
    --parameters arm-template.parameters.json \
```

**Using Powershell**

```powershell
New-AzResourceGroupDeployment `
    -ResourceGroupName az-204-study-rg `
    -TemplateFile ./arm-template.json `
    -TemplateParameters ./arm-template.parameters.json
```
