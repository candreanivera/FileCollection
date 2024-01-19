/**
This programs generates a report with all the files in the current directory and its size.
It only considers Word, Excel and PPT files.
*/

// Get the path for the current directory
string path = Directory.GetCurrentDirectory();
Console.WriteLine($"The current directory is: {path}");

//Creates the new file when the report is going to be generated
string report = "report_of_files.txt";
Console.WriteLine($"El archivo existe antes?: {File.Exists(report)}");

//If a previous report existed, it's deleted
if(File.Exists(report)){
    File.Delete(report); 
}


//List of strings with all the files in the directory
List<string> list = new List<string>(Directory.EnumerateFiles(path));


//Variables for the kind of files
int docx = 0;
int xlsx = 0;
int pptx = 0;

//Variables for the sizes of the files
long size_docx = 0;
long size_xlsx = 0;
long size_pptx = 0;

foreach(string i in list){
    //Variables that will store the kind of files
    bool ext_doc = i.EndsWith("docx");
    bool ext_ppt = i.EndsWith("pptx");
    bool ext_xls = i.EndsWith("xlsx");

    FileInfo path_i = new FileInfo(i);
    long size_file = 0;
    size_file = path_i.Length;

    if (ext_doc == true){
            docx ++;
            size_docx = size_docx + size_file;
    }else
        if(ext_ppt == true){
            pptx ++;
            size_pptx = size_pptx + size_file;
        }else
        if(ext_xls == true){
            xlsx++;
            size_xlsx = size_xlsx + size_file;
        };
 
    //Generates the report with the amount of files
    using (StreamWriter sw = File.CreateText(report)){
        sw.WriteLine("Report of files:");
        sw.WriteLine($"Word Files  :   {docx}");
        sw.WriteLine($"Excel Files :   {xlsx}");
        sw.WriteLine($"PPT Files   :   {pptx}");
        sw.WriteLine(" ");
    }

    //updates report with sizes of files
    using (StreamWriter sw = File.AppendText(report)){
        sw.WriteLine("Report of sizes:");
        sw.WriteLine($"Word Files  :   {size_docx:N0}");
        sw.WriteLine($"Excel Files :   {size_xlsx:N0}");
        sw.WriteLine($"PPT Files   :   {size_pptx:N0}");
    }

}