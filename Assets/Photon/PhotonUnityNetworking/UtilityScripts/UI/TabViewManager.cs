using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Photon.Pun.UtilityScripts
{
    /// <summary>
    /// Tab view manager. Handles Tab views activation and deactivation, and provides a Unity Event Callback when a tab was selected.
    /// </summary>
    public class TabViewManager : MonoBehaviour
    {
        /// <summary>
        /// Tab change event.
        /// </summary>
        [System.Serializable]
        public class TabChangeEvent : UnityEvent<string> { }

        [Serializable]
        public class Tab
        {
            public string ID = "";
            public Toggle Toggle;
            public GameObject View; // Changed to GameObject to represent tank views as GameObjects
        }

        /// <summary>
        /// all the tabs for this group
        /// </summary>
        public Tab[] Tabs;

        /// <summary>
        /// The on tab changed Event.
        /// </summary>
        public TabChangeEvent OnTabChanged;

        protected Tab CurrentTab;

        void Start()
        {
            foreach (Tab _tab in this.Tabs)
            {
                _tab.Toggle.onValueChanged.AddListener((isSelected) =>
                {
                    if (isSelected)
                    {
                        OnTabSelected(_tab);
                    }
                });
            }

            // Initially select the first tab
            if (Tabs.Length > 0)
            {
                OnTabSelected(Tabs[0]);
            }
        }

        /// <summary>
        /// final method for a tab selection routine
        /// </summary>
        /// <param name="tab">Tab.</param>
        public void OnTabSelected(Tab tab)
        {
            // Deactivate all views
            foreach (Tab _t in Tabs)
            {
                _t.View.SetActive(false);
            }

            // Activate the selected view
            tab.View.SetActive(true);

            // Invoke the event with the ID of the selected tab
            OnTabChanged.Invoke(tab.ID);
        }
    }
}
