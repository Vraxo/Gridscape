﻿using Raylib_cs;

namespace Gridscape;

public partial class TopPanel : Panel
{
    private ProjectSaver projectSaver;
    private ProjectExporter projectExporter;
    private LeftPanel leftPanel;

    public override void Start()
    {
        Size = new(0, 35);

        leftPanel = GetNode<LeftPanel>("LeftPanel");
        projectSaver = GetChild<ProjectSaver>();
        projectExporter = GetChild<ProjectExporter>();

        GetChild<Button>("SaveButton").LeftClicked += OnSaveButtonLeftClicked;
        GetChild<Button>("ExportButton").LeftClicked += OnExportButtonLeftClicked;
    }

    public override void Update()
    {
        UpdatePosition();
        UpdateSize();
        base.Update();
    }

    private void UpdatePosition()
    {
        Position = new(leftPanel.Size.X - 1, 0);
    }

    private void UpdateSize()
    {
        Size = new(MathF.Ceiling(Raylib.GetScreenWidth() - Position.X), Size.Y);
    }

    private void OnSaveButtonLeftClicked(object? sender, EventArgs e)
    {
        projectSaver.Save();
    }

    private void OnExportButtonLeftClicked(object? sender, EventArgs e)
    {
        projectExporter.Export();
    }
}