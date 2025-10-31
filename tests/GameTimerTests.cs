using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Mmc.MonoGame.Utils.Tests
{
    [TestClass]
    public sealed class GameTimerTests
    {
        private static bool AreNearlyEqual(double a, double b, double epsilon)
        {
            double diff = Math.Abs(a - b);
            return diff <= epsilon;
        }

        private static void RunNonLoopingTimer(GameTimer timer, TimeSpan dt, int maxUpdates)
        {
            TimeSpan total = TimeSpan.Zero;

            timer.Start();

            int currentUpdate;
            for (currentUpdate = 0; currentUpdate < maxUpdates && timer.Enabled; currentUpdate++)
            {
                total += dt;
                timer.Update(new GameTime(total, dt));
            }

            if (currentUpdate == maxUpdates)
            {
                Assert.Fail("Max update count reached, something went wrong");
            }
        }

        [TestMethod]
        public void UpdateMethodBeingCalled()
        {
            TimeSpan dt = TimeSpan.FromSeconds(1f / 16f);

            GameTimer timer = new GameTimer();
            timer.Duration = TimeSpan.FromSeconds(1);

            bool wasUpdateEventCalled = false;

            timer.Updated += (s, e) => wasUpdateEventCalled = true;

            int maxUpdateCount = 1000;

            RunNonLoopingTimer(timer, dt, maxUpdateCount);

            Assert.IsTrue(wasUpdateEventCalled, "Update event was never called");
        }

        [TestMethod]
        public void CompleteMethodBeingCalled()
        {
            TimeSpan dt = TimeSpan.FromSeconds(1f / 16f);

            GameTimer timer = new GameTimer();
            timer.Duration = TimeSpan.FromSeconds(1);

            bool wasCompletedEventCalled = false;

            timer.TimerCompleted += (s, e) => wasCompletedEventCalled = true;

            int maxUpdateCount = 1000;

            RunNonLoopingTimer(timer, dt, maxUpdateCount);

            Assert.IsTrue(wasCompletedEventCalled, "Completed event was never called");
        }

        [TestMethod]
        public void CorrectDeltaTimes()
        {
            const double DurationSeconds = .5;
            TimeSpan totalTime = TimeSpan.Zero;

            const double DtSeconds = 1f / 60f;// simulate 60 fps
            TimeSpan dt = TimeSpan.FromSeconds(DtSeconds);

            const double Epsilon = DtSeconds / 100f; // give 1% error on the 60fps target

            GameTimer timer = new GameTimer();

            timer.SetDurationInSeconds(DurationSeconds);

            int updateCount = 0;
            timer.Updated += (s, e) =>
            {
                updateCount++;

                Debug.WriteLine($"Current Time: {e.CurrentTime.TotalMilliseconds}\n" +
                    $"Duration: {e.Duration.TotalMilliseconds}\n" +
                    $"Percent Complete: {e.CurrentTime / e.Duration * 100:f2}%\n" +
                    "----------------------------");

                Assert.IsTrue(AreNearlyEqual(Math.Min(DtSeconds * updateCount, DurationSeconds), e.CurrentTime.TotalSeconds, Epsilon));
            };

            int maxUpdateCount = 1000;

            RunNonLoopingTimer(timer, dt, maxUpdateCount);
        }

        [TestMethod]
        public void ScheduledActions()
        {
            TimeSpan dt = TimeSpan.FromSeconds(1f / 60f);

            GameTimer timer = new GameTimer();

            const int TotalSeconds = 2;
            timer.Duration = TimeSpan.FromSeconds(TotalSeconds);

            int scheduledActionsCallBackCount = 0;
            void scheduledAction() => scheduledActionsCallBackCount++;

            const int ScheduledActions = 30;

            for (int i = 0; i < ScheduledActions; i++)
            {
                TimeSpan scheduledTime = TimeSpan.FromSeconds((float)i / ScheduledActions * (float)TotalSeconds);
                Debug.WriteLine($"Scheduled time at {scheduledTime.TotalSeconds} seconds.");
                timer.ScheduleTimeAction(scheduledTime, scheduledAction);
            }

            int maxUpdateCount = 1000;

            RunNonLoopingTimer(timer, dt, maxUpdateCount);

            Assert.AreEqual(ScheduledActions, scheduledActionsCallBackCount);
        }
    }
}
