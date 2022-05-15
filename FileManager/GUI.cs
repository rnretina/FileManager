﻿namespace FileManager
{
    [Serializable]
    public class GUI
    {
        public string Font { get; set; }
        public string Theme { get; set; }

        public GUI()
        {
            Font = Fonts[0];
            Theme = Themes[0];
        }
        public string[] Fonts =  {"Arial", "Segoe UI", "Georgia", "Century", "Rockwell"};
        public string[] Themes = { "White", "Material Ocean", "Night Owl"};
    }
}
