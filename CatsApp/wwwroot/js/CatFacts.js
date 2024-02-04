// CatFacts.js

document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('nextButton').addEventListener('click', function () {
        getNextCatFact();
    });
});

async function getNextCatFact() {
    const response = await fetch('CatFacts/GetNextFact');
    const fact = await response.json();

    const ul = document.getElementById('catFactsList');

    // Usuń wszystkie istniejące elementy z listy
    while (ul.firstChild) {
        ul.removeChild(ul.firstChild);
    }

    // Dodaj nowy fakt do listy
    const li = document.createElement('li');
    li.textContent = fact.text;
    ul.appendChild(li);
}
