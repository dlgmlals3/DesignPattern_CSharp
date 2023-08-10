﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;
using DesignPattern.Builder;

using DesignPattern.Builder.FluentBuilder;
using Grammar.Delegation;
using Grammar.LINQ;
namespace DesignPattern
{
	class Program
	{
		static void Main(string[] args)
		{
			Grammar_LinqTest();
		}

		public static void Grammar_LinqTest()
		{
			new LINQ().Test();
		}

		public static void Grammar_EventTest() {
			DelegateGrammar.Test();
			DelegateGrammar.MultiTest();
			EventTest.Test();
			EventTest.AnonymouseTest();
			EventTest.LamdaTest();
			EventTest.InlineLambdaTest();
			EventTest.FuncTest();
			EventTest.ActionTest();
			EventTest.PredicateTest();
			new EventTest().EventHandlerTest();
			new ExpressionGrammar().ExpressionTest();
			new ExpressionGrammar().ExpressionBodyTest();
			new SwitchExpression().Test();
		}

		public static void DesignPattern_Builder()
		{
			DesignPattern.Builder.Builder.builder_1();
			FluentBuilder.builder_fluentBuilder_2();
			StepWiseBuilder.Test();
			FunctionalBuilder.Test();
		}

		public static void DesignPattern_SolidPattern()
		{
			Solid_Patterns.Structure_1();	
			Solid_Patterns.Filter_2();	
			Solid_Patterns.OpenClosed_3();
			Solid_Patterns.Sustitution_4();
			Solid_Patterns.DependentInversion_5();
		}

	}
}