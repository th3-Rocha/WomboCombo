using UnityEngine;
using System.Collections;

namespace TMPro.Examples
{
    public class VertexColorCycler : MonoBehaviour
    {
        private TMP_Text m_TextComponent;
        public Color32[] colors = new Color32[] { new Color32(255, 0, 0, 255), new Color32(0, 255, 0, 255), new Color32(0, 0, 255, 255) }; // Define your colors here
        private int colorIndex = 0;

        void Awake()
        {
            m_TextComponent = GetComponent<TMP_Text>();
        }

        void Start()
        {
            StartCoroutine(AnimateVertexColors());
        }

        /// <summary>
        /// Method to animate vertex colors of a TMP Text object.
        /// </summary>
        /// <returns></returns>
        IEnumerator AnimateVertexColors()
        {
            // Force the text object to update right away so we can have geometry to modify right from the start.
            m_TextComponent.ForceMeshUpdate();

            TMP_TextInfo textInfo = m_TextComponent.textInfo;
            int currentCharacter = 0;

            Color32[] newVertexColors;
            Color32 c0 = m_TextComponent.color;

            while (true)
            {
                int characterCount = textInfo.characterCount;

                // If No Characters then just yield and wait for some text to be added
                if (characterCount == 0)
                {
                    yield return new WaitForSeconds(0.25f);
                    continue;
                }

                // Get the index of the material used by the current character.
                int materialIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;

                // Get the vertex colors of the mesh used by this text element (character or sprite).
                newVertexColors = textInfo.meshInfo[materialIndex].colors32;

                // Get the index of the first vertex used by this text element.
                int vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;

                // Only change the vertex color if the text element is visible.
                if (textInfo.characterInfo[currentCharacter].isVisible)
                {
                    c0 = colors[colorIndex]; // Use the current color from the array

                    newVertexColors[vertexIndex + 0] = c0;
                    newVertexColors[vertexIndex + 1] = c0;
                    newVertexColors[vertexIndex + 2] = c0;
                    newVertexColors[vertexIndex + 3] = c0;

                    // Update the vertex data
                    m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
                }

                currentCharacter = (currentCharacter + 1) % characterCount;
                colorIndex = (colorIndex + 1) % colors.Length; // Cycle through the colors

                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
