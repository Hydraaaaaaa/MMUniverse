using System.Collections.Generic;
using System;

public class GlobalSetEventArgs {
	public string key;
	public object value;
}

public class Globals {
	private static Globals instance = null;
	private Dictionary<string, object> Values;
	public delegate void SetEventHandler(GlobalSetEventArgs e);
	public event SetEventHandler SetEvent;

	private Globals()  {
		Values = new Dictionary<string, object> ();
	}

	public static Globals Get() {
		if (Globals.instance == null) {
			Globals.instance = new Globals ();
		}
		return Globals.instance;
	}

	public void SetValue(string key, object value) {
		if (!Values.ContainsKey (key)) {
			Values.Add (key, value);
		} else {
			Values[key] = value;
		}
		GlobalSetEventArgs e = new GlobalSetEventArgs ();
		if (SetEvent != null) {
			e.key = key;
			e.value = value;
			SetEvent(e);
		}
	}

	public object SetValue(string name) {
		return Values[name];
	}

	public object this[string key] {
		get {
			return SetValue(key);
		}
		set {
			SetValue(key, value);
		}
	}
}
