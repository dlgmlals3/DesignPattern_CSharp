using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
	// 데코레이터 디자인 패턴 
	// Delegation을 통해 내부 변수에 interface 등록
	// 상속받은 인터페이스를 통해 오버라이딩 함수 구현
	// 오버라이딩 함수에서 인터페이스 내부 변수를 통해 함수 호출..

	public class Document
	{

	}
	public interface IMachine
	{
		void Print(Document d);
		void Scan(Document d);
		void Fax(Document d);
	}

	public class MultiFunctionPrinter : IMachine
	{
		public void Fax(Document d)
		{
			//
		}

		public void Print(Document d)
		{
			//
		}

		public void Scan(Document d)
		{
			//
		}
	}

	public class OldFashionPrinter : IMachine
	{
		public void Fax(Document d)
		{
			//
		}

		public void Print(Document d)
		{
			//
		}

		public void Scan(Document d)
		{
			//
		}
	}

	public interface IPrinter
	{
		void print(Document d);
	}
	public interface IScanner
	{
		void Scan(Document d);
	}

	public class Photocopier : IPrinter, IScanner
	{
		public void print(Document d)
		{
			throw new NotImplementedException();
		}

		public void Scan(Document d)
		{
			throw new NotImplementedException();
		}
	}

	public interface IMultiFunctionDevice : IScanner, IPrinter //...
	{

	}

	public class MultiFunctionMachine : IMultiFunctionDevice
	{
		private IPrinter printer;
		private IScanner scanner;
		public MultiFunctionMachine(IPrinter printer, IScanner scanner)
		{
			if (printer == null)
			{
				throw new ArgumentNullException(paramName: nameof(printer));
				throw new ArgumentNullException(paramName: nameof(scanner));
			}
			this.printer = printer;
			this.scanner = scanner;
		}

		public void print(Document d)
		{
			printer.print(d);
		}

		public void Scan(Document d)
		{
			scanner.Scan(d);
		} // 데코레이터
	}
}
