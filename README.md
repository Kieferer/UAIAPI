# UAI-API
![Build & Deploy Status](https://github.com/kieferer/uaiapi/actions/workflows/UAI-API.yml/badge.svg)
### Universal Auto-update Intermediary API

Usage and planned features
* Repo/project registration with a private key through HTTP requests, sent by automatized pipelines like GitHub actions when a new project release is published.
* Store the binaries of a release, and be able to replace them with the latest one.
* Generate a static JSON file for auto-updaters of a stored project, so a client can decide if it needs to be updated or not.
  Example for Tauri-updater:
  ```
  {
    "version": "v1.0.0",
    "notes": "Test version",
    "pub_date": "2020-06-22T19:25:57Z",
    "platforms": {
      "darwin-x86_64": {
        "signature": "Content of app.tar.gz.sig",
        "url": "https://github.com/username/reponame/releases/download/v1.0.0/app-x86_64.app.tar.gz"
      },
      "darwin-aarch64": {
        "signature": "Content of app.tar.gz.sig",
        "url": "https://github.com/username/reponame/releases/download/v1.0.0/app-aarch64.app.tar.gz"
      },
      "linux-x86_64": {
        "signature": "Content of app.AppImage.tar.gz.sig",
        "url": "https://github.com/username/reponame/releases/download/v1.0.0/app-amd64.AppImage.tar.gz"
      },
      "windows-x86_64": {
        "signature": "Content of app-setup.nsis.sig or app.msi.sig, depending on the chosen format",
        "url": "https://github.com/username/reponame/releases/download/v1.0.0/app-x64-setup.nsis.zip"
      }
    }
  }
  ```
  
