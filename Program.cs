using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;
using DesignPattern.Builder;
using DesignPattern.Builder.FacetedBuilder;
using DesignPattern.Builder.FluentBuilder;
using DesignPattern.Factory;
using DesignPattern.Factory.FactoryClass;
using DesignPatterns.Factory.AbstractFactory;
using DesignPatterns.Factory.OCP;
using DesignPatterns.Factory.Assignment;
using DesignPatterns.ProtoType;
using DesignPatterns.ProtoType.DeepCopy;
using DesignPatterns.ProtoType.Inheritance;
using DesignPatterns.ProtoType.Interface;
using DesignPatterns.ProtoType.Serialization;
using DesignPatterns.ProtoType.AssignMent;
using DesignPatterns.Singleton;
using DesignPatterns.Singleton.Issue;
using DesignPatterns.Singleton.Monostate;

using Grammar.Delegation.Publisher;
using Grammar.Delegation;
using Grammar.LINQ;
using Grammar.Generic;
using Grammar.Collections.List;
using Grammar.Collections.Dictionary;
using Grammar.Collections.SortedList;
using Grammar.Collections.HashTable;
using Grammar.Collections.IEnumerableCollection;
using Grammar.Collections.CustomCollection;
using Grammar.Collections.GenericCustomCollection;
using Grammar.Collections.ICollectionE;
using Grammar.Collections.IListE;
using Grammar.Collections.IEquatableExample;
using Grammar.Collections.IComparableExample;
using Grammar.Collections.Contraraiance;
using Grammar.Collections.Covariance;
using Grammar.Collections.ArrayListExam;
using Grammar.Collections.CollectionOfObject;
using Grammar.Collections.IEnumeratorAndYield;
using Grammar.Collections.Assignments;

namespace DesignPattern
{
	class Program
	{
		static void Main(string[] args)
		{
			DesignPattern_SingleTon();
		}

		#region Grammar

		public static void Grammar_Collection()
		{
			ListCollection.Test();
			DictionaryCollection.Test();
			
			IEnumerableCollection.Test();
			CustomCollection.Test();
			GenericCustomCollection.Test();
			ICollectionE.Test();
			IListE.Test();
			IEquatableExample.Test();
			IComparableExample.Test();
			Covariance.Test();
			Contravariance.Test();
			SortedListCollection.Test();
			HashtableCollection.Test();
			ArrayListExam.Test();
			//CollectionOfObject.Test();
			CollectionOfObject.Test2();
			IEnumeratorAndYield.Test();
			new FirstAssignments().Test();
			new SecondAssignments().Test();



		}
		public static void Grammar_Generic()
		{
			Generic.Test();
			Generic.MultiGenericTest();
			Generic.ConstraintTest();
			Generic.GenericMethodTest();
		}
		public static void Grammar_LinqTest()
		{
			LINQ.Test();
			LINQ.OrderTest();
			LINQ.FirstOrDefulat();
			LINQ.Last_LastOrDefault();
			LINQ.ElementAtOrDefault();
			LINQ.SingleOrDefault();
			LINQ.Select();
			LINQ.MinMax();
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
		#endregion

		#region Patterns
		public static void DesignPattern_SingleTon()
		{
			SingleTon.Test();
			SingleTonIssue.Test();
			Monostate.Test();
		}

		public static void DesignPattern_ProtoType()
		{
			ICloneableBad.Test();
			DeepCopy.Test();
			Inheritance.Test();
			ProtoTypeInterface.Test();
			Serialization.Test();
			AssignMent.Test();
		}

		public static void DesignPattern_Factory()
		{
			FactoryMethod.Test();
			FactoryAsync.Test();
			FactoryClass.Test();
			TrackingObject.Test();
			AbstractFactory.Test();
			//OOPFactory.Test();
			Assignment.Test();
		} 

		public static void DesignPattern_Builder()
		{
			DesignPattern.Builder.Builder.builder_1();
			FluentBuilder.builder_fluentBuilder_2();
			StepWiseBuilder.Test();
			FunctionalBuilder.Test();
			FacetedBuilder.Test();

		}

		public static void DesignPattern_SolidPattern()
		{
			Solid_Patterns.Structure_1();	
			Solid_Patterns.Filter_2();	
			Solid_Patterns.OpenClosed_3();
			Solid_Patterns.Sustitution_4();
			Solid_Patterns.DependentInversion_5();
		}
		#endregion
	}
}