## Colorconverter
#### A project that's mainly so that I can get somewhat used to C# again. Unlike my dashboard project, this is a bit simpler and therefore the project should be working at least a bit stable.
<br>
Check the releases if you want a stable and working copy of the program! The master branch might not work as stable.

The program is used to display and convert colors. It can also show a websafe version of the color, the complement of the color and a color harmony based on the analogous technique.
Whenever the program is focused it will check the clipboard for a color, and if it finds one it will switch to that at once. This should save a user some time, but it might cause frustration. Let me know what you think!

There is only one textbox the user can enter text into, right under the text Enter a color. Enter a color there and the program will do it's thing. Or, just copy a color and switch to the program again!

The colorboxes in the websafe, color harmony and complementary can all be clicked and will change the entered color to itself instead.

The program uses a Regular Expression to understand the user input, and I have tried to make it work in as many scenarios as possible.
Here is a list of examples that are all supported by the program:
```
#FF00FF
# 70FF00
HEX(FF00FF)
HEX70FF00
HEX 70FF00

RGB(25, 26, 27)
RGB( 25, 26, 27)
RGB(225,29,30)
RGB 255 29 30

RGBA 255 255 255 1
RGBA(100%,100%,100%,0.5)
RGBA(100%, 100%, 100%, 0,5)
RGBA 100% 100% 100% 0.5

RGBA(255, 0, 255, 255)
RGBA 255 0 255 127

HSL(10, 20, 20)
```
