import { useState, useEffect } from 'react';
import { Stack, Title, Grid, TextInput, Text, Textarea, Kbd, Image, rem, ScrollArea, Divider } from '@mantine/core';
import { IconTerminal } from '@tabler/icons-react';
import { json, useParams } from 'react-router-dom';

import { AIMessage, PlayerMessage } from 'src/components/playground/Messages.jsx';

function Playground() {
    const { game } = useParams();
    const [gameInfo, setGame] = useState();
    const [messages, setMessages] = useState();
    const [images, setImages] = useState();

    useEffect(() => {
        const gameFetch = async () => {
            const gameInfo = await(
                (await fetch(`/api/games/${game}`, { method: "GET" })).json()
            );

            const serverMessage = {
                "id" : crypto.randomUUID(),
                "kind": "server",
                "text": gameInfo.text
            };

            const initialMessages = [ serverMessage ];
            setMessages(initialMessages);

            setImages([ `https://placehold.co/600x400?text=${game}` ]);

            setGame(gameInfo);
        };

        gameFetch();
    }, []);

    const iconTerminal = <IconTerminal style={{ width: rem(24), height: rem(24) }} />;

    const messageWidgets = messages?.map((message) => {
        if (message.kind == "server") {
            return <AIMessage key={message.id} message={message.text} />;
        } else {
            return <PlayerMessage key={message.id} message={message.text} />;
        }
    });

    const imageWidgets = images?.map((image) => (
       <Stack>
            <Image
                radius="md"
                src={ image }
                h={500}
                w={400}
            />

            <Divider my="md" label="* * *" labelPosition="center" />
        </Stack>
    ));

    return(
        <Stack pt={24} pb={24} pl={48} pr={48}>
            <Title order={1}>{gameInfo?.gameName}</Title>
            <Grid>
                <Grid.Col span={8}>
                    <ScrollArea>
                    <Stack>
                        { messageWidgets }

                        <TextInput 
                            variant="unstyled" 
                            leftSectionPointerEvents="none" 
                            leftSection={iconTerminal}
                            placeholder="¿Qué quieres hacer?"
                            onKeyDown={(event) => {
                                if(event.key == "Enter") {
                                    const userMessage = {
                                        "id" : crypto.randomUUID(),
                                        "kind" : "user",
                                        "text" : event.currentTarget.value
                                    }

                                    setMessages(prevMessages => ([ ...prevMessages, userMessage ]));

                                    const userFetch = async () => {
                                        const userTurn = {
                                            result: event.currentTarget.value
                                        };

                                        const requestHeaders = {
                                            "Content-Type" : "application/json"
                                        };

                                        const gameInfo = await(
                                            (await fetch(`/api/games/${game}`, { method: "POST", headers: requestHeaders, body: JSON.stringify(userTurn) })).json()
                                        );
                            
                                        const serverMessage = {
                                            "id" : crypto.randomUUID(),
                                            "kind": "server",
                                            "text": gameInfo.turn.result
                                        };
                            
                                        setMessages(prevMessages => ([ ...prevMessages, serverMessage ]));
                                        setImages(prevImages => ([ ...prevImages, gameInfo.asset.url ]));
                                        console.log(gameInfo.asset.url);
                                        console.log(gameInfo);
                                    };
                            
                                    userFetch();
                                }
                            }}
                        />
                        <Text size='xs' c='dimmed'>Pulsa la tecla <Kbd>Enter</Kbd> para enviar tu comando.</Text>
                    </Stack>
                    </ScrollArea>
                </Grid.Col>
                <Grid.Col span={4}>
                    <Stack>
                    { imageWidgets }
                    </Stack>
                </Grid.Col>
            </Grid>
        </Stack>
    );
}

export default Playground;