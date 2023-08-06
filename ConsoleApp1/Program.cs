using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;
using DesignPattern_Builder;
using DesignPattern_FunctionBuilder;
using GrammarCSharp;
using GrammarCSharp_Event;
namespace DesignPattern
{
	class Program
	{
		static void Main(string[] args)
		{
			//Solid_Patterns.Structure_1();	
			//Solid_Patterns.Filter_2();	
			//Solid_Patterns.OpenClosed_3();
			//Solid_Patterns.Sustitution_4();
			//Solid_Patterns.DependentInversion_5();

			//Builder.builder_1();
			//fluentBuilder.builder_fluentBuilder_2();
			//StepWiseBuilder.Test();
			//FunctionalBuilder.Test();

			//DelegateGrammar.Test();
			//DelegateGrammar.MultiTest();

			//EventTest.Test();
			//EventTest.AnonymouseTest();
			//EventTest.LamdaTest();
			//EventTest.InlineLambdaTest();
			//EventTest.FuncTest();
			//EventTest.ActionTest();
			//EventTest.PredicateTest();
			var eventTest = new EventTest();
			eventTest.EventHandlerTest();
		}
	}
}