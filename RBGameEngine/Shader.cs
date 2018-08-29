using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK;
using System.IO;

namespace RBGameEngine
{
    public class Shader
    {

        //class variables
        private readonly int programID;

        public Shader(string vertexFileName, string fragmentFileName = null)
        {
            programID = GL.CreateProgram();

            //test to see if the program ID is returning 0
            //if the program ID is 0 write to the console that there was a problem
            //exit upon error.
            if(programID == 0)
            {
                Console.Write("Error creating shader: Could not generate program buffer.");
                Environment.Exit(1);
            }

            AddShader(vertexFileName, ShaderType.VertexShader);
            AddShader(fragmentFileName, ShaderType.FragmentShader);
            CompileShader();
        }

        private void AddShader(string fileName, ShaderType type)
        {
            //method variables
            string shader = ReadShader(fileName);
            int shaderID = GL.CreateShader(type);

            if (shaderID == 0)
            {
                Console.WriteLine("Error creating shader: Could not generate the shader buffer.");
                Environment.Exit(1);
            }

            //Get the shader information to be used
            //Compile the shader with passing shaderID
            //Get the shager compile status and pass out to compileStatus
            GL.ShaderSource(shaderID, shader);
            GL.CompileShader(shaderID);
            GL.GetShader(shaderID, ShaderParameter.CompileStatus, out int compileStatus);

            //test for compileStatus being equal to 0
            //if equal to 0 write to console stating there was an error
            //as well writ to the console with the ShaderInfoLog passing the value to shaderID
            //exit once complete
            if (compileStatus == 0)
            {
                Console.WriteLine("Error compiling shader: Could not compile the shader.");
                Console.WriteLine(GL.GetShaderInfoLog(shaderID));
                Environment.Exit(1);
            }
        }

        private void CompileShader()
        {

            //Link the program with GL.LinkProgram to the programID
            //Get the status of the program and pass it to the linkStatus
            GL.LinkProgram(programID);
            GL.GetProgram(programID, GetProgramParameterName.LinkStatus, out int linkStatus);

            //Test if the linkStatus is equal to 0
            //if equal to 0 write to the console that there was an error
            //get the program info log passing that to the programID
            //exit once done.
            if(linkStatus == 0)
            {
                Console.WriteLine("Error linking shader program: Could not link shader program!");
                Console.WriteLine(GL.GetProgramInfoLog(programID));
                Environment.Exit(1);
            }

            //Validate the program to the programID
            //Get the program status and out put to the validationStatus
            GL.ValidateProgram(programID);
            GL.GetProgram(programID, GetProgramParameterName.ValidateStatus, out int validationStatus);

            //Check if validationStatus is equal to 0
            //Write to the console if there is an error stating could not validate
            //Write to the console with the programID
            //exit once done
            if(validationStatus == 0)
            {
                Console.WriteLine("Error validating program: Could not validate shader program!");
                Console.WriteLine(GL.GetProgramInfoLog(programID));
                Environment.Exit(1);
            }
        }

        public void StartShader()
        {
            GL.UseProgram(programID);
        }

        public void StopShader()
        {
            GL.UseProgram(0);
        }

        private static string ReadShader(string fileName)
        {
            StringBuilder shader = new StringBuilder();

            //this is to try reading a line and appending it with an new line at the end
            //If this has an error we will catch the execption in the catch statement.
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        shader.AppendLine(line).Append("\n");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            return shader.ToString();
        }
    }
}
