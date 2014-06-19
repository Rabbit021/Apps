using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern
{
	public class Client
	{
		private Packaging _packaging;
		public Packaging Packaging
		{
			get { return _packaging; }
		}
		private DeliveryDocument _deliverDocument;
		public DeliveryDocument DeliverDocument
		{
			get { return _deliverDocument; }
		}

		public Client(PackDelvFactory factory)
		{
			_packaging = factory.CreatePackaging();
			_deliverDocument = factory.CreateDeliverDocument();
		}
	}

	public abstract class PackDelvFactory
	{
		public abstract Packaging CreatePackaging();
		public abstract DeliveryDocument CreateDeliverDocument();
	}

	public class StandardFactory : PackDelvFactory
	{

		public override Packaging CreatePackaging()
		{
			return new StandardPackaging();
		}

		public override DeliveryDocument CreateDeliverDocument()
		{
			return new Postal();
		}
	}

	public class ShockProofFactory : PackDelvFactory
	{

		public override Packaging CreatePackaging()
		{
			return new ShockProofPackaging();
		}

		public override DeliveryDocument CreateDeliverDocument()
		{
			return new Courier();
		}
	}

	//
	public abstract class Packaging { }
	public class StandardPackaging : Packaging { }
	public class ShockProofPackaging : Packaging { }

	public abstract class DeliveryDocument { }
	public class Postal : DeliveryDocument { }
	public class Courier : DeliveryDocument { }
}
