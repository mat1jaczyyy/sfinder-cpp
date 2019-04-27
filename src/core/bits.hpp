#ifndef CORE_BITS_HPP
#define CORE_BITS_HPP

#include <cassert>

#include "types.hpp"

namespace core {
    Bitboard deleteLine_(Bitboard x, LineKey key);

    Bitboard deleteLine(Bitboard x, LineKey mask);

    Bitboard insertBlackLine_(Bitboard x, LineKey key);

    Bitboard insertBlackLine(Bitboard x, LineKey mask) ;

    Bitboard insertWhiteLine_(Bitboard x, LineKey key) ;

    Bitboard insertWhiteLine(Bitboard x, LineKey mask);

    int bitCount(Bitboard b);
}

#endif //CORE_BITS_HPP