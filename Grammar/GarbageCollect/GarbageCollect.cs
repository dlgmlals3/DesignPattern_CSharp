using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Grammar.GarbageCollect
{
	class a
	{
		// CLR은 메모리 매니저다.

		// CLR은 오브젝트 생성할때 메모리를 생성하고 가비지 컬렉터의 역할도 한다.
		// CLR은 가비지 컬렉션이라는 프로세스를 통해 오브젝트 힙 메모리 회수한다.
		// 새로운 앱이 시작될때마다 힙이 생성된다. 힙size 64MB 보통.

		// 가비지 컬렉터가 동작하는 시기는 CLR이 메모리를 생성때 공간이 부족하면 실행된다.
		// 수동으로 가비지 컬렉터를 동작시키려면 GC.Collect() 실행하면 된다.

		// 가비지 컬렉터의 수집 대상은
		// 참조되지 않는 오브젝트의 경우이다. dead Object라고 말한다.

		// CLR은 가비지 컬렉션 수행하기 위해,
		// Mark and Compact 알고리즘을 사용한다.
		// Mark and Compact 알고리즘은 3가지 segment로 나뉘어 진다.

		// Generation 2 - 사용을 하지 않는 오래 생존하고 있는 오브젝트
		// Generation 1 - 많이 사용하고 있는 오브젝트
		// Generation 0 - 방금 생성한 오브젝트

		// 가비지 컬렉터는 Generation2에 있는 오브젝트 대상으로 가비지 컬렉션이 이루어진다.
	}

	// Unmanaged Resources
	// 데이터베이스 연결할때 사용하는 리소스는 Unmanaged Resources에 포함 된다.
	// 파일 읽기 쓰기와 같이 OS에서 사용하는 리소스의 경우도 Unmanaged Resources에 포함된다.
	// Managed Resources 경우는 애플리 케이션이 종료되기 전에,
	// 가비지 컬렉션에 의해 객체가 전부 삭제된다.

	// 그럼 UnManaged Resource는 누가 관리하나요 ?
	// 데이터베이스와 파일의 연결이 되어 있는 경우, 메모리 릭이 발생할수 있다.
	// C#은 Unmanaged Resource 메모리 회수를 위해 소멸자를 제공한다.
	// Destructor, Dispose 두가지 방법이 있다.
	// Destructor는 어플리케이션 실행 끝에 실행되는 반면 로그로 확인 X
	// 반면 Dispose는 명시적으로 호출한다.

	// Destructor
	// ~ClassName() { // body } 

	public class GarbageCollect
	{
		public GarbageCollect()
		{
			Console.WriteLine("GarbageCollect");
		}
		~GarbageCollect()
		{
			Console.WriteLine("~GarbageCollect");
		}
	}

	// DisPosable
	// 명시적으로 호출되어, 메모리 제거 가능.
	// dispose 함수 호출되기 위해서는 해당 클래스에 IDisposable interface 을 상속하고,
	// dispose 함수 override 한다.
	// 그리고 해당 클래스를 사용할때는 반드시 using 구문 안에서 해야한다.
	public class DisposableTest : System.IDisposable
	{
		// constructor 
		public void Sample()
		{
			Console.WriteLine("Database connected");
		}

		// method
		public  void DisplayDataFromDatabase()
		{
			Console.WriteLine("Reading data from database");
		}

		public void Dispose()
		{
			Console.WriteLine("Distabase disconnected");
		}
	}


	public class GarbageCollectTest 
	{
		public void Test()
		{
			Console.WriteLine("Test Start");
			Test1();
			Console.WriteLine("Test End");

			// 블락 빠져나가면 자동으로 dispose 호출.
			// using block 써야 Dispose 호출이 된다.
			using (DisposableTest s = new DisposableTest()) 
			{
				s.DisplayDataFromDatabase();
			} // s Distabase disconnected 호출

			// using 키워드를 type앞에 사용해도 동일한 효과 발생.
			using DisposableTest k = new DisposableTest();
			k.DisplayDataFromDatabase();
		} // k Distabase disconnected 호출 


		public void Test1()
		{
			Console.WriteLine("Test1 Start");
			GarbageCollect a = new GarbageCollect();
			Console.WriteLine("Test1 End");
		}
	}

}
