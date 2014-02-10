using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SQLiteSample
{
	public partial class SQLiteSampleViewController : UIViewController
	{
		protected string _dbName = "db_sqlitesample.db3"; 
		protected List<Person> _people = new List<Person> ();

		public SQLiteSampleViewController () : base ("SQLiteSampleViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		partial void btnCreateDB (NSObject sender)
		{
			CreateDatabase();
			lblOutput.Text = "Database created";
		}

		partial void btnAddPerson (NSObject sender)
		{
			AddPerson();
			lblOutput.Text = "People added";
		}

		partial void btnGetCount (NSObject sender)
		{
			int rowCount = GetCount();
			lblOutput.Text = "Number of records: " + rowCount;
		}

		#region DBMethods
		protected string GetDBPath (string dbName)
		{
			// get a reference to the documents folder
			var documents = Environment.GetFolderPath (Environment.SpecialFolder.Personal);

			// create the db path
			string db = Path.Combine (documents, dbName);

			return db;
		}

		protected void CreateDatabase()
		{
			// create a connection object. if the database doesn't exist, it will create 
			// a blank database
			using(SQLiteConnection db = new SQLiteConnection (GetDBPath (_dbName)))
			{				
				// create the tables
				db.CreateTable<Person> ();
				// close the connection
				db.Close ();
			}
		}

		protected void AddPerson()
		{
			// create a connection object. if the database doesn't exist, it will create 
			// a blank database
			using(SQLiteConnection db = new SQLiteConnection (GetDBPath (_dbName)))
			{				
				// declare vars
				List<Person> people = new List<Person> ();
				Person person;

				// create a list of people that we're going to insert
				person = new Person () { FirstName = "Peter", LastName = "Gabriel" };
				people.Add (person);
				person = new Person () { FirstName = "Thom", LastName = "Yorke" };
				people.Add (person);
				person = new Person () { FirstName = "J", LastName = "Spaceman" };
				people.Add (person);
				person = new Person () { FirstName = "Benjamin", LastName = "Gibbard" };
				people.Add (person);

				// insert our people
				db.InsertAll (people);

				// close the connection
				db.Close ();
			}
		}

		protected int GetCount()
		{
			int personCount;
			using (SQLiteConnection db = new SQLiteConnection (GetDBPath (_dbName))) {
				// query a list of people from the db
				List<Person> people = new List<Person> (from p in db.Table<Person> ()
				                           select p);

				personCount = people.Count;
			};
			return personCount;
		}

		#endregion
	}
}

