using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor.Tilemaps
{
    [CreateAssetMenu(fileName = "My Custom Flip Brush", menuName = "Brushes/My Custom Flip Brush", order = 361)]
    [CustomGridBrush(true, false, false, "My Custom Flip Brush")]
    public class FlipBrush : GridBrush
    {
        public bool flipX;
        public bool flipY;

        public override void Pick(GridLayout gridLayout, GameObject brushTarget, BoundsInt position, Vector3Int pickStart)
        {
            if (flipX)
                base.Flip(FlipAxis.X, gridLayout.cellLayout);
            if (flipY)
                base.Flip(FlipAxis.Y, gridLayout.cellLayout);

            base.Pick(gridLayout, brushTarget, position, pickStart);

            if (flipX)
                base.Flip(FlipAxis.X, gridLayout.cellLayout);
            if (flipY)
                base.Flip(FlipAxis.Y, gridLayout.cellLayout);

        }

        public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
        {
            base.Paint(gridLayout, brushTarget, position);
        }
    }
    [CustomEditor(typeof(FlipBrush))]
    public class FlipBrushEditor : GridBrushEditor
    {
        public override void OnPaintSceneGUI(GridLayout gridLayout, GameObject brushTarget, BoundsInt position, GridBrushBase.Tool tool, bool executing)
        {
            base.OnPaintSceneGUI(gridLayout, brushTarget, position, tool, executing);
            string labelText = "pos : " + position.position;
            Handles.Label(gridLayout.CellToWorld(position.position), labelText);
        }
    }

}
