using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
public class MenuObject : StringEventInvoker
{

	#region Fields

	private readonly string _CLONE = "(Clone)";
	#endregion

	#region Protected Methods

	/// <summary>
	/// Traduce el text de todos los
	/// objetos Text al idioma actual
	/// <para>
	/// Solo si el idioma actual es
	/// distinto al predeterminado
	/// </para>
	/// </summary>
	protected virtual void Initialize()
	{
		if (ConfigurationUtils.Language != ConfigurationUtils.Language_DEFAULT)
		{
			Text[] texts = transform.GetComponentsInChildren<Text>();

			foreach (Text text in texts)
			{
				text.text = TextName(text);
			}
		}
	}

	protected virtual void Awake()
	{
		Initialize();
	}

	/// <summary>
	/// Obtiene el nombre del objeto Texto
	/// en el diccionario del idioma actual
	/// para traducirlo
	/// </summary>
	/// <param name="text">Object Text</param>
	/// <returns>Text.name</returns>
	protected string TextName(Text text)
	{
		text.name.Replace(_CLONE, "");
		return ConfigurationUtils.Dict[text.name][ConfigurationUtils.Language.ToString()];
	}
	#endregion
}