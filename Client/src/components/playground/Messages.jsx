import { Group, Paper, Avatar, Text, Stack } from '@mantine/core';


export function AIMessage(props) {
    const messageReceivedTime = `${(new Date()).getHours()}:${(new Date()).getMinutes()}`;

    return(
        <Paper shadow="xs" p="sm" bg='var(--mantine-color-gray-0)'>
            <Group p={8} wrap="nowrap">
                <Avatar radius='sm' size='xl' mr={8} src='/images/master.jpg' />
                <Stack justify='flex-start'>
                    <Text size='md'>{props.message}</Text>
                    <Group justify='flex-start'>
                        <Text size='sm' c='dimmed'>Recibido a las { messageReceivedTime }</Text>
                    </Group>
                </Stack>
            </Group>
        </Paper>
    );
}

export function PlayerMessage(props) {
    const messageSendedTime = `${(new Date()).getHours()}:${(new Date()).getMinutes()}`;

    return(
        <Paper shadow="xs" p="sm" bg='var(--mantine-color-gray-0)'>
            <Group p={8} wrap="nowrap">
                <Stack justify='flex-start'>
                    <Text size='md' ta='right'>{props.message}</Text>
                    <Group justify='flex-end'>
                        <Text size='sm' c='dimmed'>Enviada a las { messageSendedTime }</Text>
                    </Group>
                </Stack>
                <Avatar radius='sm' size='xl' color='blue' ml={8}>AV</Avatar>
            </Group>
        </Paper>
    );
}