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

### Aufgabe 2 & 3
**22.06.2022**
- Münzen drehen sich jetzt um die z-Achse
- die Kamera bewegt sich nun nur noch in x-Richtung mit dem Spieler mit, sodass sie in y-Richtung statisch bleibt (Kamera springt nicht mit, wenn der Spieler springt)
- neue Assets für Fässer und Boxen/Kisten als zusätzliche Hindernisse mit eigens ausgeschnittenem Sprite
- rollende Fässer hinzugefügt und ebenfalls mit einem Factory-Skript versehen, sodass sie zufällig generiert werden können
  - die Fässer rollen auf den Spieler zu und überrollen dabei auch alle Skelette, die ihnen in den Weg kommen (allerdings kein Einfluss auf Kisten)
- Hinzufügen einer Kanone mit Ladebalken, welcher in der linken oberen Ecke platziert ist. Dieser füllt sich, wenn der Spieler in der Nähe der Kanone ist und die Leertaste 1 Sekunde lang gedrückt hält 
  - ist der Ladebalken voll und wird die Leertaste losgelassen, schießt eine Kanonenkugel auf das unüberwindbare Hinderniss, welches hinter der Kanone platziert ist
    - lässt der Spieler die Leertaste nicht los, wird die Kugel spätestens dann abgefeuert, wenn der Spieler auf Höhe der Kanone ist
  - die Kugel fällt aufgrund der Gravitation auf den Boden, wo sie dann zerstört wird. Somit ergibt sich eine "natürliche Grenze" für die Schussweite 
- Hinzufügen von Musik & Tönen für verschiedene Aktionen
  - **TODO: Erklärung**
- Implementierung des Double Jumps
  - wenn der Spieler sich in der Luft befindet, kann er einmalig durch Drücken der Leertaste "erneut springen". Hierbei wird die aktuelle Position und Geschwindigkeit in der Luft benutzt und ausgehend davon, ein neuer Sprung ausgeführt
  - ein zweiter Sprung am Ende der Flugphase ist also genauso effektiv, wie ein zweiter Sprung direkt nach dem Ersten 

Somit ist Aufgabe 2 abgeschlossen und für das Abschließen von Aufgabe 3 fehlt nur noch das weitere Interactable.

### Aufgabe 3 & 4
**28.06.22**
- als zweites Interactable wurde ein Glas Bier hinzugefügt, das durch Halten der Leertaste eingesammelt werden kann und den Spieler für 5 Sekunden unsterblich macht
  - in diesem Modus werden alle Objekte, mit denen der Spieler normalerweise kollidiert wäre, zerstört

Mit diesem Item ist Aufgabe 3 abgeschlossen! :)

- Hinzufügen von Marinesoldaten, die auf den Spieler zulaufen und in zufälligen Abständen mit ihrer Pistole schießen
  - die Kugel wird nicht von der Schwerkraft beeinflusst und fliegt mit konstanter Gesschwindigkeit durch alle Hindernisse hindurch ohne mit ihnen zu interagieren
- wie bei den anderen Hindernissen, werden auch die Marinesoldaten mittels einer Factory in zufälligen Zeitabständen erzeugt
- um die Kanone aus Aufgabe 3 wurde eine "Sperrzone" eingerichtet, in der keine Gegner spawnen können, sodass das Interactable nicht beeinträchtigt wird
- verschiedene Deko-Elemente wurden zum ersten Level hinzugefügt
  - neue Assets für Fische, Muscheln, Steine, Schatzkarte und Schatztruhe
- Ausarbeitung einer Geschichte für das Spiel und Implementierung des Spielendes im ersten Level
  - der Spieler muss in eine Schatzkarte springen, die Hinweise darauf gibt, wo sich der verlorene Papagei des Piraten befindet. Über die 5 Level des Spiels erhält der Pirat nun weitere Hinweise über den Aufenthaltsort und findet schließlich seinen Papagei auf dem Schiff der Marinesoldaten
  - über die Schatzkarte gelangt man in den Endscreen eines jeden Levels, in dem die Geschichte fortgesetzt und der Score angezeigt wird
  
An festen Zielen fehlt uns somit nur noch die farbliche Vorwarnung des Spielers über Hindernisse am rechten Bildschirmrand und die Implementierung bzw. Verbesserung der Sounds im Spiel. Abschließend werden dann die restlichen vier Spiellevel erstellt.
