# UAI-API
### Universal Auto-update Intermediary API
[![Build and deploy UAI-API .NET Core ASP.NET application to Azure](https://github.com/Kieferer/UAIAPI/actions/workflows/UAI-API.yml/badge.svg?branch=development)](https://github.com/Kieferer/UAIAPI/actions/workflows/UAI-API.yml)
<br/>
UAI-API is an ASP.NET application that stores metadata of the last releases of Tauri applications for their auto-updater services.

## Features
* Register a new release of a project with a private key through an HTTP request, sent by automatized pipelines of a published or updated Tauri application.
* Store the information of releases and direct download link of binaries.
* Send metadata of a project in JSON for auto-updaters of a stored project.

## Examples

Tauri-updater needs a JSON structure (like the following one displayed) to analyze the incomming metadata of the version of the latest release.
If the latest release is newer than the currently used one, then a dialog window pop-up which by the user can decide if its wants the update or not.
(custom update dialog also can be implemented in Tauri)
The JSON has to contain platform specific direct download link for installers of the supported desktop platforms.

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
> For further information, check the Github Actions workflow of my project, [LECUA](https://github.com/Kieferer/LECUA)
> and the documentation of tauri-updater [Tauri-Updater](https://tauri.app/v1/guides/distribution/updater/)
