using ICities;

namespace LoadingScreenMod
{
	public sealed class Mod : IUserMod, ILoadingExtension
	{
		private static bool created;

		public string Name => "Loading Screen Mod for Airports DLC (Temporary Updated)";

		public string Description => "New loading options. Temporary fix by Klyte45. Fork from latest version";

		public void OnSettingsUI(UIHelperBase helper)
		{
			Settings.settings.OnSettingsUI(helper);
		}

		public void OnCreated(ILoading loading)
		{
		}

		public void OnReleased()
		{
		}

		public void OnLevelLoaded(LoadMode mode)
		{
		}

		public void OnLevelUnloading()
		{
		}

		public void OnEnabled()
		{
			L10n.SetCurrent();
			if (!created)
			{
				if (BuildConfig.applicationVersion.StartsWith("1.14"))
				{
					Instance<LevelLoader>.Create().Deploy();
					created = true;
				}
				else
				{
					Util.DebugPrint(L10n.Get(9));
				}
			}
		}

		public void OnDisabled()
		{
			Instance<LevelLoader>.instance?.Dispose();
			Settings.settings.helper = null;
			created = false;
		}
	}
}
