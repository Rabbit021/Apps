using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GMap
{
	public class FileOperation : IOperationFile<Student>
	{
		public List<Student> stus = new List<Student>()
		{
			new Student{Id="1",Name="John",Score1=90,Score2=80,Score3=70},
			new Student{Id="1",Name="John",Score1=90,Score2=80,Score3=70},
			new Student{Id="1",Name="John",Score1=90,Score2=80,Score3=70},
			new Student{Id="1",Name="John",Score1=90,Score2=80,Score3=70},
			new Student{Id="1",Name="John",Score1=90,Score2=80,Score3=70},
			new Student{Id="1",Name="John",Score1=90,Score2=80,Score3=70}
		};
		string FileName = "d:/Test.bin";
		public void ReadInfo(IList<Student> stus)
		{
			using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
			{
				using (var br = new BinaryReader(fs))
				{
					this.stus.Clear();
					do
					{
						try
						{
							Student student = new Student();
							student.Id = br.ReadString();
							student.Name = br.ReadString();
							student.Score1 = br.ReadDouble();
							student.Score2 = br.ReadDouble();
							student.Score3 = br.ReadDouble();
							stus.Add(student);
							student = null;
						}
						catch
						{
							break;
						}
					} while (true);

				}
			}
			foreach (var itr in stus)
			{
				Console.WriteLine(itr.Name);
			}
		}


		public void WriteInfo(IList<Student> stus)
		{
			using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write))
			{
				using (BinaryWriter writer = new BinaryWriter(fs))
				{
					foreach (Student student in stus)
					{
						writer.Write((String)student.Id);
						writer.Write((String)student.Name);
						writer.Write((Double)student.Score1);
						writer.Write((Double)student.Score2);
						writer.Write((Double)student.Score3);
						writer.Flush();
					}
				}
			}
		}
	}

	public class Student
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public double Score1 { get; set; }
		public double Score2 { get; set; }
		public double Score3 { get; set; }
	}
}
