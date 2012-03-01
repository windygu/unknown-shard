using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class dexincreaser2000 : Item
	{
		[Constructable]
		public dexincreaser2000 () : base( 0x241D )
		{
			base.Weight = 10.0;
			Name = "Dexterity Potion Level 8";
		}

		public dexincreaser2000 ( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{

			if ( from.InRange( this.GetWorldLocation(), 1 ) )
			{

				if( ( ( from.RawStr + from.RawInt + from.RawDex ) >= from.StatCap ) || from.RawDex >= 2000 )
				{
					from.SendMessage( "You are too dexterous" );
					return;
				}
				else
				{
					from.RawDex += 1;
					Delete();
				}
			}
			else
			{
				from.SendMessage( "Too far away to drink" );
				return;
			}

		}
	}
}