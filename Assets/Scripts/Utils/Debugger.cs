using UnityEngine;
using System.Collections;

public class Debugger {

	static public void log(string msg,string id,bool addLocation = false)
	{
		if(!hasId(id)) return;
		
		Debug.Log(msg);
	}
	
	static private bool hasId( string id )
	{
		return indexOf(DebugSettings.INTERESTS,id) > -1;
	}
	static private int indexOf(string[] stringArray,string currentString)
	{
		for (int i = 0; i < stringArray.Length; i++) {
			if(stringArray[i] == currentString)
			{
				return i;
			}
		}
		return -1;
	}
}
