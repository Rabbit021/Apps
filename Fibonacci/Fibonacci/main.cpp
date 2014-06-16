#include <iostream>
#include <cmath>

using namespace std;

#define  INT long long
#define FLOAT float

void Fibonacci (int n );
INT GetFibonacciAtN(int n);

const float constant = sqrt(5);
FLOAT x1 = (1+constant)/2;
FLOAT x2 = (1-constant)/2;

///主函数
int main()
{
	Fibonacci(70);
	system("pause");
	return 0;
}

//计算前n位 
void Fibonacci (int n )
{
	for(int i =0; i<n;i++)
		cout << GetFibonacciAtN(i) <<endl;
}

//计算第n位(n 从0开始)
INT GetFibonacciAtN(int n)
{
	return (INT)floor((pow(x1,n) - pow(x2,n)) /constant);
}