# Alerts

<p class="lead mb-2">Provide contextual feedback messages for typical user actions with the handful of available and flexible alert messages.</p>
<br />

### Examples

Alerts are available for any length of text, as well as an optional close button.
<br />
{{{
  "Alert": {
    "Text": "A simple primary alert - check it out!",
    "Color": "Primary",
    "IsDismissible": false
  }
}}}
<br />
{{{
  "Alert": {
    "Text": "A simple secondary alert - check it out!",
    "Color": "Secondary",
    "IsDismissible": false
  }
}}}
<br />
{{{
  "Alert": {
    "Text": "A simple success alert - check it out!",
    "Color": "Success",
    "IsDismissible": false
  }
}}}
<br />
{{{
  "Alert": {
    "Text": "A simple danger alert - check it out!",
    "Color": "Danger",
    "IsDismissible": false
  }
}}}
<br />
{{{
  "Alert": {
    "Text": "A simple warning alert - check it out!",
    "Color": "Warning",
    "IsDismissible": false
  }
}}}
<br />
{{{
  "Alert": {
    "Text": "A simple info alert - check it out!",
    "Color": "Info",
    "IsDismissible": false
  }
}}}
<br />
{{{
  "Alert": {
    "Text": "A simple light alert - check it out!",
    "Color": "Light",
    "IsDismissible": false
  }
}}}
<br />
{{{
  "Alert": {
    "Text": "A simple dark alert - check it out!",
    "Color": "Dark",
    "IsDismissible": false
  }
}}}

<br />

### Icons

Similarly, you can use flexbox utilities and Bootstrap Icons to create alerts with icons. Depending on your icons and content, you may want to add more utilities or custom styles.
<br />

{{{
  "Alert": {
    "Text": "An example alert with an icon",
    "Color": "Primary",
    "IsDismissible": false,
    "Icon": {
        "Icon": "warning",
        "Color": "Primary",
        "IsSolid": true
    }
  }
}}}
<br />

### Dismissing

Using the alert JavaScript plugin, it's possible to dismiss any alert inline. Here's how:
<br />
* Be sure you've loaded the alert plugin, or the compiled Bootstrap JavaScript.

You can see this in action with a live demo:
<br />

{{{
  "Alert": {
    "Text": "A simple warning alert - check it out!",
    "Color": "Warning",
    "IsDismissible": true
  }
}}}
<br />

{{{
  "Callout": {
    "Message": "When an alert is dismissed, the element is completely removed from the page structure. If a keyboard user dismisses the alert using the close button, their focus will suddenly be lost and, depending on the browser, reset to the start of the page/document. For this reason, we recommend including additional JavaScript that listens for the `closed.bs.alert event` and programmatically sets `focus()` to the most appropriate location in the page. If you're planning to move focus to a non-interactive element that normally does not receive focus, make sure to add `tabindex=\"1\"` to the element.",
    "Color": "Info"
  }
}}}