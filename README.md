# QuickDoc

### What:
Command-line utility to generate a HTML document from a Markdown file. Includes Bootstrap 3.0.3 CSS for formatting. Uses MarkdownSharp to actually transform the input text from Markdown to HTML.

### Why:
One of my clients likes to have a text file in the root of each project with basic information about the project, deployment instructions, etc. Since plain text files suck for anything of substantial length, documentation is often as short as it can possibly be. I created QuickDoc in hopes of making it easier to add lightweight, formatted documentation that can still be packaged in a single file.

### Usage:
    > QuickDoc.exe inputFile.md

QuickDoc will create an output file with the same name as the input file, but with the `.htm` extension. For example, `documentation.md` becomes `documentation.htm`.

To specify the output file name, pass it in as an argument:

    > QuickDoc.exe inputFile.md outputFile.htm
