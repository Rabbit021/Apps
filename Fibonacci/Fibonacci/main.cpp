#include <iostream>
#include <cmath>

using namespace std;

#define  INT long long

void Fibonacci (int n );
INT GetFibonacciAtN(int n);

//const float constant = sqrt(5);
//float x1 = (1+sqrt(5))/2;
//float x2 = (1-sqrt(5))/2;

INT Fibonaccis[70];
void InitFibonacci();

///主函数
int main()
{
	InitFibonacci();
	Fibonacci(70);
	system("pause");
	return 0;
}

//计算前n位 
void Fibonacci (int n )
{
	for(int i =0; i<n;i++)
	{
		if(GetFibonacciAtN(i) !=Fibonaccis[i] )
		{
			cout<< "False"<<endl;
			cout <<i<<"\t"<<GetFibonacciAtN(i) <<"\t"<< Fibonaccis[i]<<endl;
		}
	}
}

//计算第n位(n 从0开始)
INT GetFibonacciAtN(int n)
{
	float x1 = ( 1 + sqrt(5) ) / 2;
	float x2 = (1 - sqrt(5) ) / 2;  
	return (INT)floor( (pow(x1,n) - pow(x2,n)) /sqrt(5));
}

void InitFibonacci()
{
	Fibonaccis[0]=0;
	Fibonaccis[1]=1;
	for (int i = 2; i <= 70; i++)
		Fibonaccis[i] = Fibonaccis[i-1]+Fibonaccis[i-2];
}

