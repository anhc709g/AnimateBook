﻿using System;
using Firebase;
using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;

namespace Book.RTDatabase
{
	public class BookGeneralInfo
	{
		public int id;
		public string category;
		public BookInfoDetail infoDetail;

		public class BookInfoDetail
		{
			public string name;
			public int status;
			public float price;
			public string picture_url;
			public string description;
			public string version;
			public string min_app_version;

			public BookInfoDetail(string name, int status, float price, string picture_url, string description, string version, string min_app_version)
			{
				this.name = name;
				this.status = status;
				this.price = price;
				this.picture_url = picture_url;
				this.description = description;
				this.version = version;
				this.min_app_version = min_app_version;
			}
		}

		public BookGeneralInfo (string category, int id, string name, int status, float price, string picture_url, string description, string version, string min_app_version)
		{
			this.id = id;
			this.category = category;
			infoDetail = new BookInfoDetail(name, status, price, picture_url, description, version, min_app_version);
		}

		public void pushToServer(DatabaseReference databaseReference)
		{
			string json = JsonUtility.ToJson (infoDetail);
			databaseReference
				.Child ("public")
				.Child("books")
				.Child(category)
				.Child(id.ToString())
				.SetRawJsonValueAsync (json);
		}
	}

}
