namespace SimpleUI
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	/// <summary>
	/// Scheduler. A class for managing recurring Tasks in arbitrary
	///invervals or scheduling future Actions
	/// </summary>
	public sealed class Scheduler : SimpleEasing.UnitySingleton<Scheduler>
	{

		/// <summary>
		/// Creates the task. If number of Executions is negative(default), then the task will execute indefinitely at the given interval rate
		/// </summary>
		/// <returns>The Coroutine for the task.</returns>
		/// <param name="task">Task.</param>
		/// <param name="interval">Interval.</param>
		/// <param name="NumberOfExecutions">Number of executions.</param>
		public static Coroutine Repeat(Action task, float interval = 1f, int NumberOfExecutions = -1)
		{
			if (NumberOfExecutions == 0) return null;
			return instance.StartCoroutine(instance.Task(task, new WaitForSeconds(interval), NumberOfExecutions));
		}

		public static Coroutine RepeatIndefinitely(Action task, float interval = 1f)
		{
			return instance.StartCoroutine(instance.Task(task, new WaitForSeconds(interval), -1));
		}

		public static Coroutine DoInFuture(Action task, float delay = 1f)
		{
			return Repeat(task, delay, 1);
		}

		public static Coroutine DoWhen(Func<bool> condition, Action callbackWhenTrue, float CheckInterval,
			bool DoOnlyOnce = true)
		{
			return instance.StartCoroutine(instance.WatchTask(condition, callbackWhenTrue, new WaitForSeconds(CheckInterval),
				DoOnlyOnce));
		}

		public static Coroutine DoWhen(Func<bool> condition, Action callbackWhenTrue, bool DoOnlyOnce = true)
		{
			return instance.StartCoroutine(instance.WatchTask(condition, callbackWhenTrue, null, DoOnlyOnce));
		}

		public static Coroutine DoWhile(Func<bool> condition, Action task, Func<bool> endCondition)
		{
			return instance.StartCoroutine(instance.DoWhileTask(condition, task, endCondition, null));
		}

		public static Coroutine DoUntil(Action task, Func<bool> endCondition)
		{
			return instance.StartCoroutine(instance.DoUntilTask(task, endCondition, null));
		}

		public static Coroutine DoUntil(Action task, Func<bool> endCondition, float interval)
		{
			return instance.StartCoroutine(instance.DoUntilTask(task, endCondition, new WaitForSeconds(interval)));
		}

		public static Coroutine DoWhile(Func<bool> condition, Action task, Func<bool> endCondition, float interval)
		{
			return instance.StartCoroutine(instance.DoWhileTask(condition, task, endCondition, new WaitForSeconds(interval)));
		}

		public static Coroutine DoForeach<T>(IList<T> elements, Action<T> task, float interval = 1f, Action OnFinished = null)
		{
			return instance.StartCoroutine(instance.ForEachTask<T>(elements, task, new WaitForSeconds(interval), OnFinished));
		}

		public static Coroutine DoForeach<T>(IList<T> elements, Action<T> task, AnimationCurve customStagger,
			float averageTime = 1f, Action OnFinished = null)
		{
			return instance.StartCoroutine(
				instance.ForEachTaskNonLinear<T>(elements, task, customStagger, averageTime, OnFinished));
		}

		public static void EndTask(Coroutine cor)
		{
			instance.StopCoroutine(cor);
		}

		/// <summary>
		/// Executes a Task every other frame.
		/// </summary>
		/// <returns>The Coroutine.</returns>
		/// <param name="Task">Task.</param>
		/// <param name="frameAmount">Frame amount.</param>
		public static Coroutine RepeatEveryOtherFrame(Action Task, int FrameToExecuteOn)
		{
			return instance.StartCoroutine(instance.Task(Task, FrameToExecuteOn, FrameToExecuteOn));
		}

		private IEnumerator Task(Action task, int frameAmount, int currentFrame)
		{
			yield return null;
			currentFrame--;
			if (currentFrame == 0)
			{
				task();
				currentFrame = frameAmount;
			}
			StartCoroutine(Task(task, frameAmount, currentFrame));

		}

		private IEnumerator Task(Action task, WaitForSeconds wait, int nrExecutions)
		{
			yield return wait;
			task();
			nrExecutions--;
			if (nrExecutions != 0) StartCoroutine(Task(task, wait, nrExecutions));
		}

		private IEnumerator DoWhileTask(Func<bool> condition, Action task, Func<bool> endcondition, YieldInstruction waitTime)
		{
			yield return waitTime;
			if (condition()) task();
			if (endcondition != null && endcondition()) yield break;
			else StartCoroutine(DoWhileTask(condition, task, endcondition, waitTime));
		}

		private IEnumerator DoUntilTask(Action task, Func<bool> endcondition, YieldInstruction waitTime)
		{
			yield return waitTime;
			task();
			if (endcondition != null && endcondition()) yield break;
			else StartCoroutine(DoUntilTask(task, endcondition, waitTime));
		}

		private IEnumerator WatchTask(Func<bool> condition, Action callbackWhenTrue, YieldInstruction wait,
			bool endWhenTrue = true)
		{
			yield return wait;
			if (condition())
			{
				callbackWhenTrue();
				if (endWhenTrue) yield break;
			}
			else
				StartCoroutine(WatchTask(condition, callbackWhenTrue, wait, endWhenTrue));
		}

		private IEnumerator ForEachTask<T>(IList<T> elements, Action<T> task, YieldInstruction wait, Action OnFinished = null)
		{
			for (int i = 0, elementsCount = elements.Count; i < elementsCount; i++)
			{
				T obj = elements[i];
				task(obj);
				//No delay after the last element
				if (i < elementsCount - 1)
					yield return wait;
			}
			if (OnFinished != null)
				OnFinished();
		}

		/// <summary>
		/// Supply an Animation Curve for custom staggering, a flat line around 1 should result in an even
		/// delay for all staggered animations. A deviation above 1 should result in a longer, a deviation below 1
		/// should result in a shorter gap between animations
		/// </summary>
		/// <param name="elements"></param>
		/// <param name="task"></param>
		/// <param name="interpolation"></param>
		/// <param name="averageTime"></param>
		/// <param name="OnFinished"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		private IEnumerator ForEachTaskNonLinear<T>(IList<T> elements, Action<T> task,
			AnimationCurve interpolation, float averageTime, Action OnFinished = null)
		{
			for (int i = 0, elementsCount = elements.Count; i < elementsCount; i++)
			{
				T obj = elements[i];
				float progress = (float) i / (float) elementsCount;
				float delay = interpolation.Evaluate(progress) * averageTime;
				task(obj);
				//No delay after the last element
				if (i < elementsCount - 1)
					yield return new WaitForSeconds(delay);
			}
			if (OnFinished != null)
				OnFinished();
		}
	}

	public static class SchedulerExtensions
	{
		/// <summary>
		/// Executes an Action for each element and pause for the interval time between each action, then executes OnFinished if it's passed in
		/// </summary>
		/// <returns>The for each.</returns>
		/// <param name="enumerable">Enumerable.</param>
		/// <param name="TaskToExecute">Task to execute.</param>
		/// <param name="interval">Interval.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static Coroutine DelayedForEach<T>(this IList<T> enumerable, Action<T> TaskToExecute, float interval = 1f,
			Action OnFinished = null)
		{
			return Scheduler.DoForeach<T>(enumerable, TaskToExecute, interval, OnFinished);
		}

		public static Coroutine DelayedForEach<T>(this IList<T> enumerable, Action<T> TaskToExecute,
			AnimationCurve customStagger,
			float averageInterval = 1f, Action OnFinished = null)
		{
			return Scheduler.DoForeach<T>(enumerable, TaskToExecute, customStagger, averageInterval, OnFinished);
		}

		public static void ReplaceOrStartScheduledAction(this SimpleEasing.UniqueCoroutine ur, Coroutine cr)
		{
			ur.ReplaceOrStartCoroutine(cr, Scheduler.instance);
		}
	}
}