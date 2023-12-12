import { Group, Image, Title } from '@mantine/core';
import classes from 'src/components/header/AppLogo.module.css';

function AppLogo() {
    return (
        <Group justify='space-between' pr={24} pl={24}>
            <Image h={48} w={48} radius='md' src='/images/TechTalkGames-Logo.jpg' />
            <Title order={1} class={classes.logo}>Tech·Talk·Games</Title>
        </Group>
    );
}

export default AppLogo;