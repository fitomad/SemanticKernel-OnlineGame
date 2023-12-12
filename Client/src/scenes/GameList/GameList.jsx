import { useState, useEffect } from 'react';
import { SimpleGrid } from "@mantine/core";
import GameCard from 'src/components/games/GameCard.jsx';

function GameList() {
    const [gameList, setGames] = useState();

    useEffect(() => {
        const gameListFetch = async () => {
            const gameList = await(
                (await fetch('api/games')).json()
            );
            console.log(gameList);
            setGames(gameList);
        };

        gameListFetch();
    }, []);

    const cards = gameList?.map((game) => ( 
        <GameCard
            key={game.gameID}
            heroImage={`/images/games/${game.gameID}.jpg`}
            name={game.name}
            summary={game.description}
        />
    ));    

    return(
        <SimpleGrid cols={4} p={24}>
            {cards}
        </SimpleGrid>
    );
}

export default GameList;