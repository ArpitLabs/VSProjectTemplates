# VSProjectTemplates
Create and Distribute Visual Studio Project Template

Project ClassLibraryTemplate is a Project Template that contains the template of barebone C# class library project and on top of that it adds a nuget package StyleCop.Analyzers. So when a project is created using this project template, StyleCop.Analyzers is preinstalled.

The project template also demostrates use of custom template wizard, that simply derives the relative path of project being created from the solution directory. It then creates a new custom parameter $relativepathfromsolutiondirectory$ and injects it into the dictionary. Project Templates can use this parameter for example it is used in the the cspro.
