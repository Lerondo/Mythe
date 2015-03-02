using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillDatabase : MonoBehaviour {
	private List<Skill> _allSkills = new List<Skill>();
	void Awake()
	{
		_allSkills.Add(new StrongSlash());
	}
}
