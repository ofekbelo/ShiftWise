import { createTheme } from '@mui/material/styles';

export const makeTheme = (dir: 'ltr' | 'rtl' = 'rtl') =>
    createTheme({
        direction: dir,
        typography: {
            fontSize: 14,
        },
    });
