# OneButtonGame

## Dev-Diary
Dies ist das "Developer Diary" von Lars Gudjons, Tim Maier und Fabian Jörg Krauß für das One-Button-Game "XYZ", das im Rahmen des Serious Games Moduls an der TU Darmstadt im Sommersemester 2022 entwickelt wurde.

### Aufgabe 1
**31.05.22**
- Download von Unity und Erstellen eines 3D Projektes


**14.06.22**
- Erstellen einer Kamera und eines Zylinders, der den Player symbolisiert
- Kamera ist an die Player-Position geheftet und folgt ihm
- Player bewegt sich mit konstanter Geschwindigkeit nach rechts
- verschiedene Piraten-Assets hinzugefügt
  - anfängliche Probleme beim Import, da mehrere Scenes den gleichen Namen hatten
- Collision Detector für Player und ein Fass als erstes Hindernis
- Player kann springen
  - verschiedene Konfigurationen für Masse und Schwerkraft ausprobiert
- Erstellen von Hauptmenü und Endscreen
  - vom Hauptmenü gelangt man in die MainPirateScene (das Spiel) und bei einer Kollision mit einem Hindernis kommt man automatisch in den Endscreen
- Hinzufügen eines Scores, der pro Frame inkrementiert wird
  - der Score wird im Spiel in einem Textfeld angezeigt, das der Bewegung des Players folgt

Mit diesen Ergebnissen wurde Aufgabe 1 erfolgreich abgeschlossen! :)

### Aufgabe 2
**15.06.22** <br>
Nach mehreren Problemen mit der Ausrichtung von Objekten in Relation zur Kamera haben wir uns entschlossen, ein neues Projekt in 2D zu erstellen und die bisherigen Ergebnisse auf das neue Projekt zu übertragen.
Ein weiterer Vorteil hierbei ist, dass wir nun das bereitgestellte Asset-Set nutzen können.

**21.06.22**
- Erzeugung von Collectables in Form von Coins, die beim Einsammeln den Score erhöhen
- Implementierung einer "CoinFactory", die in zufälligen Zeitabständen neue Coins erstellt, die kurz hinter dem Bildrand spawnen
- Erzeugung von Skeletten als bewegliche Hindernisse/Gegner
  - die Skelette wechseln in zufälligen Zeitabständen die Bewegungsrichtung und kollidieren nicht mit Kisten 
- Anwendung des Factory-Prinzips auf Kisten und Skelette, sodass auch diese nun zufällig erstellt werden
  - für jeden Objekttyp wurde ein eigenes Factory-Skript erstellt und die relevanten Variablen so deklariert, dass sie bequem aus der Unity-GUI geändert werden können
- Hinzufügen eines DEBUG-Modus, in dem man nicht mit Hindernissen kollidiert (vereinfacht das Testen des Spiels) 
