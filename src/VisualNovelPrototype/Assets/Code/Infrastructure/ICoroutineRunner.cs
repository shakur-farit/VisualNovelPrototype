using System.Collections;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
	public interface ICoroutineRunner
	{
		Coroutine StartCoroutine(IEnumerator load);
	}
}