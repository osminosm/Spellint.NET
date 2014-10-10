Spellint.NET
============

A Small library for Number Spelling

This would spell (convert) numbers to strings like '3746' would output : Three Thousand Seven Hundred FourtySix.

The library may support many languages other than english.

Currently We Have : Arabic, French.

We would love to see other contributors helping with other Languages.


Example
=======

string str = Spellint.English.Spell(233434);

// str == Two Hundred ThirtyThree Thousand Four Hundred ThirtyFour  

string str = Spellint.Arabic.Spell(233434);

// str == مائتان و ثلاثة و ثلاثون الف و أربعة مائة و أربعة و ثلاثون  

string str = Spellint.French.Spell(233434);

// str == deux cent trente trois mille quatre cent trente quatre
