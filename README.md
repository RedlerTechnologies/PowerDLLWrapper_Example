# PowerDLLWrapper_Example
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
