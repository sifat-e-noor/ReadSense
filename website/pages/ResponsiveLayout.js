import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Menu from '@mui/material/Menu';
import MenuIcon from '@mui/icons-material/Menu';
import Container from '@mui/material/Container';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import AdbIcon from '@mui/icons-material/Adb';
import CssBaseline from '@mui/material/CssBaseline';
import useScrollTrigger from '@mui/material/useScrollTrigger';
import Stack from '@mui/material/Stack';
import { Add, AddRounded, ArrowBackIosNewRounded, BackHandRounded, RemoveRounded } from '@mui/icons-material';
import PropTypes from 'prop-types';
import styles from '../components/layout.module.css';
import NumberInput from '../components/NumberInput';
import CustomRadioChip from '../components/CustomRadioChip';
import Image from 'next/image';
import Input from '../components/input';
import AlignmentToggle from '../components/toggleButton';
import ToggleButton from '@mui/material/ToggleButton';
import FormatAlignLeftIcon from '@mui/icons-material/FormatAlignLeft';
import FormatAlignCenterIcon from '@mui/icons-material/FormatAlignCenter';
import FormatAlignRightIcon from '@mui/icons-material/FormatAlignRight';
import FormatAlignJustifyIcon from '@mui/icons-material/FormatAlignJustify';
import ViewWeekOutlinedIcon from '@mui/icons-material/ViewWeekOutlined';
import TableRowsOutlinedIcon from '@mui/icons-material/TableRowsOutlined';

const pages = ['Products', 'Pricing', 'Blog'];
const settings = ['Profile', 'Account', 'Dashboard', 'Logout'];

const CustomTextInputForNumber = (props) => {
    const [inputValue, setInputValue] = React.useState(props.value);

    React.useEffect(() => {
        const handler = setTimeout(() => {
            if (typeof props.changeHandler === 'function') {

                var value = undefined;
                if (props.type === 'int') {
                    value = parseInt(inputValue);
                } else if (props.type === 'float') {
                    value = parseFloat(inputValue);
                } else {
                    value = inputValue;
                }
                if (isNaN(value) || value < props.min || value > props.max || value === props.value) {
                    setInputValue(props.value);
                    return;
                }
                if (props.type === 'float') {
                    var multiplier = Math.pow(10, 1);
                    value = (Math.round(value * multiplier) / multiplier).toFixed(1);
                }
                if (props.value == value) {
                    setInputValue(value);
                } else {
                    props.changeHandler(value);
                }
            }
        }, 1000);

        return () => {
            clearTimeout(handler);
        };
    }, [inputValue, props.changeHandler]);

    React.useEffect(() => {
        setInputValue(props.value);
    }, [props.value]);

    return (
        <Input type="text" value={inputValue} changeHandler={setInputValue} />
    )
}

function ResponsiveAppBar(props) {
    const [anchorElNav, setAnchorElNav] = React.useState(null);
    const [anchorElUser, setAnchorElUser] = React.useState(null);
    const [fonts, setFonttype] = React.useState('sans-serif');

    const handleOpenNavMenu = (event) => {
        setAnchorElNav(event.currentTarget);
    };
    const handleOpenUserMenu = (event) => {
        setAnchorElUser(event.currentTarget);
    };

    const handleCloseNavMenu = () => {
        setAnchorElNav(null);
    };

    const handleCloseUserMenu = () => {
        setAnchorElUser(null);
    };

    function ElevationScroll(props) {
        const { children, window } = props;
        // Note that you normally won't need to set the window ref as useScrollTrigger
        // will default to window.
        // This is only being set here because the demo is in an iframe.
        const trigger = useScrollTrigger({
            disableHysteresis: true,
            threshold: 0,
            target: window ? window() : undefined,
        });

        return React.cloneElement(children, {
            elevation: trigger ? 0 : 0,
        });
    }

    ElevationScroll.propTypes = {
        children: PropTypes.element.isRequired,
        /**
         * Injected by the documentation to work in an iframe.
         * You won't need it on your project.
         */
        window: PropTypes.func,
    };

    const fonttypekRadioButtonFields = [
        { label: 'Sans-serif', value: 'sans-serif' },
        { label: 'Serif', value: 'serif' },
    ];

    return (
        <>
            <CssBaseline />
            <ElevationScroll {...props}>
                <AppBar position="sticky" sx={{ background: "transparent" }}>
                    <Container maxWidth="xl" sx={{ background: "transparent" }}>
                        <Toolbar disableGutters sx={{ backgroundColor: "white" }}>
                            {/* <AdbIcon sx={{ display: { xs: 'none', md: 'flex' }, mr: 1 }} /> */}
                            <Stack spacing={.5} direction="row" alignItems={'center'}>
                                <IconButton edge="start" color="inherit" aria-label="backArrow" sx={{ mr: 2 }} onClick={''}>
                                    <ArrowBackIosNewRounded className={styles.logoColor} />
                                </IconButton>
                                <Typography variant="h6" component='div' className={styles.backText} >
                                    Back
                                </Typography>
                            </Stack>

                            <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' }, justifyContent:'flex-end'}}>
                                <IconButton
                                    size="large"
                                    aria-label="account of current user"
                                    aria-controls="menu-appbar"
                                    aria-haspopup="true"
                                    onClick={handleOpenNavMenu}
                                    color="red"
                                >
                                    <MenuIcon sx={Boolean(anchorElNav)? {color:'#735BF2', boxSizing:1, borderRadius: '4px', backgroundColor:'#E8DEF9'} : {color:'#735BF2'}}/>
                                </IconButton>
                                <Menu
                                    id="menu-appbar"
                                    // anchorEl={anchorElNav}
                                    anchorOrigin={{
                                        vertical: 'bottom',
                                        horizontal: 'right',
                                    }}
                                    keepMounted
                                    transformOrigin={{
                                        vertical: 'top',
                                        horizontal: 'right',
                                    }}
                                    open={Boolean(anchorElNav)}
                                    onClose={handleCloseNavMenu}
                                    sx={{
                                        display: { xs: 'block', md: 'none', top: '-15px'} ,
                                    }}
                                >
                                    {/* {pages.map((page) => (
                                        <MenuItem key={page} onClick={handleCloseNavMenu}>
                                            <Typography textAlign="center">{page}</Typography>
                                        </MenuItem>
                                    ))} */}
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <NumberInput min={8} max={96} value={10} changeHandler={() => { }} />
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Font size</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <Stack spacing={.5} direction="row" sx={{marginTop:'4px'}}>
                                            <CustomRadioChip
                                                handleClick={setFonttype}
                                                selected={fonts}
                                                fields={fonttypekRadioButtonFields}
                                                additionalStyles={{height:'3rem'}}
                                            />
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Font type</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', alignItems: 'center' }}>
                                        <Stack spacing={1} direction="row" sx={{alignItems: 'center'}}>
                                            < Image
                                                src="/images/format_letter_spacing_wider.png"
                                                width={0}
                                                height={0}
                                                sizes="100vw"
                                                style={{ width: '28px', height: '30px' }} // optional
                                            />
                                            <CustomTextInputForNumber type="float" min={.01} max={10} value={1.5} changeHandler={() => { }} />
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Letter spacing</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', alignItems:'center' }}>
                                        <Stack spacing={1} direction="row" sx={{ alignItems:'center'}}>
                                            < Image
                                                src="/images/letter_height.png"
                                                width={0}
                                                height={0}
                                                sizes="100vw"
                                                style={{ width: '28px', height: '30px' }} // optional
                                            />
                                            <CustomTextInputForNumber type="float" min={10} max={50} value={15} changeHandler={() => { }} />
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Line height</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <Stack spacing={1} direction="row" sx={{justifyContent:'center'}}>
                                            < AlignmentToggle defaultValue={"row"} handleChange={() => { }}>
                                                <ToggleButton value="column" aria-label="column text">
                                                    <ViewWeekOutlinedIcon />
                                                </ToggleButton>
                                                <ToggleButton value="row" aria-label="row text">
                                                    <TableRowsOutlinedIcon />
                                                </ToggleButton>
                                            </AlignmentToggle>
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Layout</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <Stack spacing={1} direction="row" sx={{justifyContent:'center'}}>
                                            < AlignmentToggle defaultValue={'left'} handleChange={() => { }}>
                                                <ToggleButton value="left" aria-label="left aligned">
                                                    <FormatAlignLeftIcon />
                                                </ToggleButton>
                                                <ToggleButton value="justify" aria-label="justified">
                                                    <FormatAlignJustifyIcon />
                                                </ToggleButton>
                                                <ToggleButton value="right" aria-label="right aligned">
                                                    <FormatAlignRightIcon />
                                                </ToggleButton>
                                            </AlignmentToggle>
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Alignment</Typography>
                                    </Stack>
                                </Menu>
                            </Box>
                            {/* big size scree menu */}
                            <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' }, justifyContent: 'center', backgroundColor: 'white', border: '0px', borderColor: 'white' }}>
                                <Box sx={{ flexGrow: 0, display: { xs: 'none', md: 'flex' }, backgroundColor: 'white', border: '1px solid hsl(0, 1%, 79%)', borderRadius: '4px', margin: '4px', justifyContent: 'space-around' }}>
                                    {/* {pages.map((page) => (
                                        <Button
                                            key={page}
                                            onClick={handleCloseNavMenu}
                                            sx={{ my: 2, color: 'white', display: 'block' }}
                                        >
                                            {page}
                                        </Button>
                                    ))} */}
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        {/* <Stack spacing={2} direction="row"> */}
                                        <NumberInput min={8} max={96} value={10} changeHandler={() => { }} />
                                        {/* </Stack> */}
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Font size</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <Stack spacing={.5} direction="row" sx={{marginTop:'4px'}}>
                                            <CustomRadioChip
                                                handleClick={setFonttype}
                                                selected={fonts}
                                                fields={fonttypekRadioButtonFields}
                                                additionalStyles={{height:'3rem'}}
                                            />
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Font type</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', alignItems: 'center' }}>
                                        <Stack spacing={1} direction="row" alignItems={'center'}>
                                            < Image
                                                src="/images/format_letter_spacing_wider.png"
                                                width={0}
                                                height={0}
                                                sizes="100vw"
                                                style={{ width: '28px', height: '30px' }} // optional
                                            />
                                            <CustomTextInputForNumber type="float" min={.01} max={10} value={1.5} changeHandler={() => { }} />
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Letter spacing</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', alignItems: 'center' }}>
                                        <Stack spacing={1} direction="row" alignItems={'center'}>
                                            < Image
                                                src="/images/letter_height.png"
                                                width={0}
                                                height={0}
                                                sizes="100vw"
                                                style={{ width: '28px', height: '30px' }} // optional
                                            />
                                            <CustomTextInputForNumber type="float" min={10} max={50} value={15} changeHandler={() => { }} />
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Line height</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <Stack spacing={1} direction="row" alignItems={'center'}>
                                            < AlignmentToggle defaultValue={"row"} handleChange={() => { }}>
                                                <ToggleButton value="column" aria-label="column text">
                                                    <ViewWeekOutlinedIcon />
                                                </ToggleButton>
                                                <ToggleButton value="row" aria-label="row text">
                                                    <TableRowsOutlinedIcon />
                                                </ToggleButton>
                                            </AlignmentToggle>
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Layout</Typography>
                                    </Stack>
                                    <Stack spacing={.5} direction="column" sx={{ margin: '6px', justifyContent: 'center' }}>
                                        <Stack spacing={1} direction="row" alignItems={'center'}>
                                            < AlignmentToggle defaultValue={'left'} handleChange={() => { }}>
                                                <ToggleButton value="left" aria-label="left aligned">
                                                    <FormatAlignLeftIcon />
                                                </ToggleButton>
                                                <ToggleButton value="justify" aria-label="justified">
                                                    <FormatAlignJustifyIcon />
                                                </ToggleButton>
                                                <ToggleButton value="right" aria-label="right aligned">
                                                    <FormatAlignRightIcon />
                                                </ToggleButton>
                                            </AlignmentToggle>
                                        </Stack>
                                        <Typography variant="h6" component='div' className={styles.HeaderLabel}>Alignment</Typography>
                                    </Stack>
                                </Box>
                            </Box>
                        </Toolbar>
                    </Container>
                </AppBar>
            </ElevationScroll>
            <Toolbar />
            <Container>
                <Box sx={{ my: 2 }}>
                    {[...new Array(12)]
                        .map(
                            () => `Cras mattis consectetur purus sit amet fermentum.
Cras justo odio, dapibus ac facilisis in, egestas eget quam.
Morbi leo risus, porta ac consectetur ac, vestibulum at eros.
Praesent commodo cursus magna, vel scelerisque nisl consectetur et.Cras mattis consectetur purus sit amet fermentum.
Cras justo odio, dapibus ac facilisis in, egestas eget quam.
Morbi leo risus, porta ac consectetur ac, vestibulum at eros.
Praesent commodo cursus magna, vel scelerisque nisl consectetur et.Cras mattis consectetur purus sit amet fermentum.
Cras justo odio, dapibus ac facilisis in, egestas eget quam.
Morbi leo risus, porta ac consectetur ac, vestibulum at eros.
Praesent commodo cursus magna, vel scelerisque nisl consectetur et.Cras mattis consectetur purus sit amet fermentum.
Cras justo odio, dapibus ac facilisis in, egestas eget quam.
Morbi leo risus, porta ac consectetur ac, vestibulum at eros.
Praesent commodo cursus magna, vel scelerisque nisl consectetur et.Cras mattis consectetur purus sit amet fermentum.
Cras justo odio, dapibus ac facilisis in, egestas eget quam.
Morbi leo risus, porta ac consectetur ac, vestibulum at eros.
Praesent commodo cursus magna, vel scelerisque nisl consectetur et.`,
                        )
                        .join('\n')}
                </Box>
            </Container>
        </>
    );
}
export default ResponsiveAppBar;
