using KamiToolKit.Classes;
using KamiToolKit.Nodes;
using KamiToolKit.Nodes.Simplified;
using FFXIVClientStructs.FFXIV.Component.GUI;
using Lumina.Data.Parsing.Uld;
using Lumina.Text.ReadOnly;
using System.Numerics;

namespace Artisan.UI.KTK
{
    internal unsafe class TextButtonNodeSynth : ButtonBase
    {
        public readonly NineGridNode BackgroundNode;
        public readonly TextNode LabelNode;

        public ReadOnlySeString String
        {
            get => LabelNode.String;
            set => LabelNode.String = value;
        }

        public uint TextId
        {
            get => LabelNode.TextId;
            set => LabelNode.TextId = value;
        }

        public TextButtonNodeSynth()
        {
            BackgroundNode = new SimpleNineGridNode
            {
                TexturePath = "ui/uld/ButtonB.tex",
                TextureSize = new Vector2(80.0f, 36.0f),
                LeftOffset = 20f,
                RightOffset = 20f,
            };
            BackgroundNode.AttachNode(this);

            LabelNode = new TextNode
            {
                AlignmentType = AlignmentType.Center,
                Position = new Vector2(16.0f, 3.0f),
                TextColor = ColorHelper.GetColor(50),
                TextOutlineColor = new Vector4(0.5569f, 0.4157f, 0.0471f, 1.0f),
                TextFlags = TextFlags.Edge | TextFlags.Emboss | TextFlags.AutoAdjustNodeSize,
                FontSize = 14,
            };
            LabelNode.AttachNode(this);

            LoadThreePartTimelines(this, BackgroundNode, LabelNode, new Vector2(16.0f, 3.0f));

            Data->Nodes[0] = LabelNode.NodeId;
            Data->Nodes[1] = BackgroundNode.NodeId;

            InitializeComponentEvents();
        }

        protected override void OnSizeChanged()
        {
            base.OnSizeChanged();

            LabelNode.Size = new Vector2(Width - 32.0f, Height - 8.0f);
            BackgroundNode.Size = Size;
        }
    }
}
