# Create Container Image for Solution

## Container Registry

- Used to create private Docker registry.

**Creating Container registry**

```bash
az acr create \
    --name az204ContainerRegistry \
    --resource-group az-204-study-rg \
    --sku standard \
    --admin-enabled true
```

**Building an Image in Container registry**

```bash
az acr build
    --file MyAwesomeDockerContainer \
    --registry az-204-container-registry \
    --image MyImage
```
