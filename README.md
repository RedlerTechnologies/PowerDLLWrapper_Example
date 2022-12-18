# PowerDLLWrapper_Example
## Prerequisites
1. Download and install .net runtime 4.7.2 (If not installed already) - https://go.microsoft.com/fwlink/?LinkId=863262
2. Download and install Kvaser driver - https://www.kvaser.com/download/
3. Download and install Canalyst-II driver - https://www.zhcxgd.com/en/nd.jsp?id=6

## To use this example using Visual Studio 2022 - 
1. Open Visual Studio 2022
2. Click "Clone a repository"
3. Paste the link of this repository in "Repositoty Location" - https://github.com/RedlerTechnologies/PowerDLLWrapper_Example.git
4. Click "Clone"

And the example is ready to go

## To use the DLL Wrapper externally
1. Clone the repository to some directory
2. In your execution project, add:
   + Refernce "PowerRiderDLLWrapper.dll" to your project (This is a .NET dll).  
   + "ControlCAN.dll" and "Kvaser.CanLib.dll" to your execution directory
   + A new directory and call it "lib"
   + The file "PowerRiderDLL.dll" to the lib directory you just created
   + Install the nuget package System.IO.Ports - https://www.nuget.org/packages/System.IO.Ports/
