import { IconBrandGithub, IconBrandLinkedin, IconWorld } from '@tabler/icons-react';
import { Group, Space, Anchor } from '@mantine/core';

function AppSocial() {
    return(
        <Group justify='center'  pr={24} pl={24}>
            <Anchor href="https://github.com/fitomad" target="_blank" underline="never" c='black'>
            <IconBrandGithub stroke={1.5} />
            </Anchor>
            <Space h='xs' />
            <Anchor href="https://www.linkedin.com/in/adolfo-vera/" target="_blank" underline="never" c='black'>
            <IconBrandLinkedin stroke={1.5} />
            </Anchor>
            <Space h='xs' />
            <Anchor href="https://medium.com/@FitoMAD" target="_blank" underline="never" c='black'>
            <IconWorld stroke={1.5} />
            </Anchor>
        </Group>
    );
}

export default AppSocial;