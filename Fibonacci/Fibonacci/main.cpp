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

///������
int main()
{
	Fibonacci(70);
	system("pause");
	return 0;
}

//����ǰnλ 
void Fibonacci (int n )
{
	for(int i =0; i<n;i++)
		cout << GetFibonacciAtN(i) <<endl;
}

//�����nλ(n ��0��ʼ)
INT GetFibonacciAtN(int n)
{
	return (INT)floor((pow(x1,n) - pow(x2,n)) /constant);
}