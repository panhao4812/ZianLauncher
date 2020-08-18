using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZianLauncher2
{
    public class mc_1_16_1
    {
        public static string relese ="1.16.1";
        public static string version = "1.16";
        public static string[] Offline_cpclass =
     {
          @"\libraries\com\mojang\javabridge\1.0.22\javabridge-1.0.22.jar;",
@"\libraries\com\mojang\patchy\1.1\patchy-1.1.jar;",
@"\libraries\oshi-project\oshi-core\1.1\oshi-core-1.1.jar;",
@"\libraries\net\sf\jopt-simple\jopt-simple\5.0.3\jopt-simple-5.0.3.jar;",
@"\libraries\commons-io\commons-io\2.5\commons-io-2.5.jar;",
@"\libraries\commons-codec\commons-codec\1.10\commons-codec-1.10.jar;",
@"\libraries\net\java\jutils\jutils\1.0.0\jutils-1.0.0.jar;",
@"\libraries\org\apache\commons\commons-lang3\3.5\commons-lang3-3.5.jar;",
@"\libraries\com\mojang\brigadier\1.0.17\brigadier-1.0.17.jar;",
@"\libraries\net\java\jinput\jinput\2.0.5\jinput-2.0.5.jar;",
@"\libraries\net\java\dev\jna\platform\3.4.0\platform-3.4.0.jar;",
@"\libraries\com\mojang\authlib\1.6.25\authlib-1.6.25.jar;",
@"\libraries\net\java\dev\jna\jna\4.4.0\jna-4.4.0.jar;",
@"\libraries\org\apache\commons\commons-compress\1.8.1\commons-compress-1.8.1.jar;",
@"\libraries\com\google\code\gson\gson\2.8.0\gson-2.8.0.jar;",
@"\libraries\commons-logging\commons-logging\1.1.3\commons-logging-1.1.3.jar;",
@"\libraries\com\mojang\datafixerupper\3.0.25\datafixerupper-3.0.25.jar;",
@"\libraries\org\apache\httpcomponents\httpcore\4.3.2\httpcore-4.3.2.jar;",
@"\libraries\org\apache\httpcomponents\httpclient\4.3.3\httpclient-4.3.3.jar;",
@"\libraries\org\apache\logging\log4j\log4j-api\2.8.1\log4j-api-2.8.1.jar;",
@"\libraries\org\lwjgl\lwjgl-jemalloc\3.2.2\lwjgl-jemalloc-3.2.2.jar;",
@"\libraries\org\lwjgl\lwjgl-openal\3.2.2\lwjgl-openal-3.2.2.jar;",
@"\libraries\org\lwjgl\lwjgl\3.2.2\lwjgl-3.2.2.jar;",
@"\libraries\org\lwjgl\lwjgl-glfw\3.2.2\lwjgl-glfw-3.2.2.jar;",
@"\libraries\org\lwjgl\lwjgl-stb\3.2.2\lwjgl-stb-3.2.2.jar;",
@"\libraries\org\lwjgl\lwjgl-tinyfd\3.2.2\lwjgl-tinyfd-3.2.2.jar;",
@"\libraries\com\google\guava\guava\21.0\guava-21.0.jar;",
@"\libraries\com\mojang\text2speech\1.11.3\text2speech-1.11.3.jar;",
@"\libraries\org\lwjgl\lwjgl-opengl\3.2.2\lwjgl-opengl-3.2.2.jar;",
@"\libraries\org\apache\logging\log4j\log4j-core\2.8.1\log4j-core-2.8.1.jar;",
@"\libraries\io\netty\netty-all\4.1.25.Final\netty-all-4.1.25.Final.jar;",
@"\libraries\com\ibm\icu\icu4j\66.1\icu4j-66.1.jar;",
@"\libraries\it\unimi\dsi\fastutil\8.2.1\fastutil-8.2.1.jar;",
@"\versions\1.16.1\1.16.1.jar"
        };
        public static string ToArguments(string _GameRootPath)
        {
            string str = "-cp ";
            for (int i = 0; i < Offline_cpclass.Length; i++)
            {
                str += _GameRootPath + Offline_cpclass[i];
            }
                return str;
        }
    }
}
