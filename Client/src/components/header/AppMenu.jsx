import { Group, Text, Space, Anchor } from '@mantine/core';

function AppMenu() {
    return(
        <Group justify='center' pr={24} pl={24}>
            <Anchor href="/" underline="never" c="black">
                <Text size='sm' fw={600} tt="uppercase">Games</Text>
            </Anchor>
            <Space h='xs' />
            <Anchor href="/privacy.html" underline="never" c="black">
                <Text size='sm' fw={600} tt="uppercase">Privacy</Text>
            </Anchor>
            <Space h='xs' />
            <Anchor href="/about.html" underline="never" c="black">
            <Text size='sm' fw={600} tt="uppercase">About</Text>
            </Anchor>
        </Group>
    );
}

export default AppMenu;